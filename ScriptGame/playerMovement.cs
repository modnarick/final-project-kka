using SimplePF2D;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;  // Movement speed
    [SerializeField] private LayerMask obstacleLayer;  // Layer mask to detect obstacles
    private Rigidbody2D body;

    private Vector2 targetPosition;  // Position the player will move to
    private bool isMoving = false;   // Is the player currently moving?

    [SerializeField]
    private TimerTurn timerTurn;

    public Animator animator;

    AudioController audioController;

    private NewEnemyMovement aStarEnemyMoving;
    private NewEnemyMovementDFS dfsEnemyMoving;
    private NewEnemyMovementBFS bfsEnemyMoving;
    private bool isSpam = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        targetPosition = body.position;  // Initialize the target position to the player's current position
        timerTurn = GameObject.Find("PlayerEnemyTurn").GetComponent<TimerTurn>();
        aStarEnemyMoving = GameObject.Find("Ghost").GetComponent<NewEnemyMovement>();
        bfsEnemyMoving = GameObject.Find("Ghost").GetComponent<NewEnemyMovementBFS>();
        dfsEnemyMoving = GameObject.Find("Ghost").GetComponent<NewEnemyMovementDFS>();
        audioController = GameObject.Find("AudioManager").GetComponent<AudioController>();
    }

    private void Update()
    {
        // Only allow input if the player isn't moving and timerTurn.timer is odd or 0 (initial state)
        if (!isMoving)
        {
            animator.SetFloat("Speed", 0);
        }

        if ((aStarEnemyMoving.isStationary || bfsEnemyMoving.isStationary || dfsEnemyMoving.isStationary) && (!isMoving && (timerTurn.timer % 2 == 1 || timerTurn.timer == 0)) && !isSpam)
        {
            // Reset the inputs before checking the key presses
            float horizontalInput = 0f;
            float verticalInput = 0f;

            // Detect button presses for WASD keys
            if (Input.GetKeyDown(KeyCode.W))  // Up (W)
            {
                verticalInput = 1;
            }
            else if (Input.GetKeyDown(KeyCode.S))  // Down (S)
            {
                verticalInput = -1;
            }
            else if (Input.GetKeyDown(KeyCode.A))  // Left (A)
            {
                horizontalInput = -1;
            }
            else if (Input.GetKeyDown(KeyCode.D))  // Right (D)
            {
                horizontalInput = 1;
            }

            // If movement input is detected
            if ((horizontalInput != 0 || verticalInput != 0) && !isMoving)
            {
                Vector2 newPosition = body.position;

                if (horizontalInput != 0)
                {
                    animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
                    newPosition = new Vector2(body.position.x + 2 * Mathf.Sign(horizontalInput), body.position.y);

                    // Dash sound will play even if timerTurn.timer == 0
                    if (timerTurn.timer == 0 && !IsObstacleInDirection(newPosition))
                    {
                        audioController.PlaySFX(audioController.dash);
                    }
                    else if (IsObstacleInDirection(newPosition) && timerTurn.timer > 0)
                    {
                        audioController.PlaySFX(audioController.hitWall);
                    }
                    else if (timerTurn.timer > 0)
                    {
                        audioController.PlaySFX(audioController.dash);
                    }
                }
                else if (verticalInput != 0)
                {
                    animator.SetFloat("Speed", Mathf.Abs(verticalInput));
                    newPosition = new Vector2(body.position.x, body.position.y + 2 * Mathf.Sign(verticalInput));

                    // Dash sound will play even if timerTurn.timer == 0
                    if (timerTurn.timer == 0 && !IsObstacleInDirection(newPosition))
                    {
                        audioController.PlaySFX(audioController.dash);
                    }
                    else if (IsObstacleInDirection(newPosition) && timerTurn.timer > 0)
                    {
                        audioController.PlaySFX(audioController.hitWall);
                    }
                    else if (timerTurn.timer > 0)
                    {
                        audioController.PlaySFX(audioController.dash);
                    }
                }

                // Only allow movement if no obstacle is detected
                if (!IsObstacleInDirection(newPosition))
                {
                    targetPosition = newPosition;
                    if (timerTurn.timer != 0)  // Increment the timerTurn only if it's not 0
                    {
                        timerTurn.timer++;
                        StartCoroutine(TimerAdd());
                    }
                    isMoving = true;
                }
                else if (timerTurn.timer != 0)  // Increment the timerTurn only if it's not 0
                {
                    timerTurn.timer++;
                    StartCoroutine(TimerAdd());
                }

                // Flip the sprite if moving horizontally
                if (horizontalInput > 0.01f)
                    transform.localScale = new Vector3(2, 2, 1);  // Facing right
                else if (horizontalInput < -0.01f)
                    transform.localScale = new Vector3(-2, 2, 1);  // Facing left
            }
        }
    }

    private void FixedUpdate()
    {
        // If the player is moving, move towards the target position
        if (isMoving)
        {
            // Move the player towards the target position
            body.position = Vector2.MoveTowards(body.position, targetPosition, moveSpeed * Time.fixedDeltaTime);

            // If the player has reached the target position, stop moving
            if (Vector2.Distance(body.position, targetPosition) < 0.01f)
            {
                body.position = targetPosition;  // Snap to the target position exactly
                isMoving = false;  // Allow new input
            }
        }
    }

    // Check if there's an obstacle in the target position
    private bool IsObstacleInDirection(Vector2 targetPos)
    {
        // Check if the target position is blocked by an obstacle
        Collider2D hit = Physics2D.OverlapCircle(targetPos, 0.1f, obstacleLayer);
        return hit != null;  // Return true if an obstacle is detected
    }

    private IEnumerator TimerAdd()
    {
        yield return new WaitForSeconds(0.4f);
        isMoving = false; // Allow new input after the timer is incremented and the movement is completed
    }

    private IEnumerator SpamDetect()
    {
        yield return new WaitForSeconds(0.8f);
        isSpam = false;
    }
}
