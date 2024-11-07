using SimplePF2D;
using System.Collections;
using UnityEngine;

public class NewEnemyMovement : MonoBehaviour
{
    private SimplePF2D.Path path;
    private Rigidbody2D rb;
    private Vector3 nextPoint;
    public bool isStationary = true;

    [SerializeField] Transform player;
    //[SerializeField] private float speed = 5.0f;
    [SerializeField] private AStarDebugDelete deleteDebug;
    [SerializeField] private TimerTurn timerTurn;

    public bool isDisabled = false;
    public float secondsMovement = 0.4f;

    private Coroutine movementCoroutine;

    void Start()
    {
        Initialize();
    }

    void OnEnable()
    {
        Initialize();
    }

    void Initialize()
    {
        timerTurn = GameObject.Find("PlayerEnemyTurn").GetComponent<TimerTurn>();
        deleteDebug = GameObject.Find("GameController").GetComponent<AStarDebugDelete>();
        path = new SimplePF2D.Path(GameObject.Find("GridPathfinding").GetComponent<SimplePathFinding2D>());
        rb = GetComponent<Rigidbody2D>();
        nextPoint = Vector3.zero;
        isStationary = true;
        isDisabled = false;
    }

    void Update()
    {
        if (!isDisabled)
        {
            if (timerTurn.timer % 2 == 1 && timerTurn.timer != 0)
            {
                path.CreatePath(transform.position, player.position);
            }

            if (path.IsGenerated() && timerTurn.timer % 2 == 0)
            {
                if (isStationary)
                {
                    if (path.GetNextPoint(ref nextPoint))
                    {
                        if (movementCoroutine == null)
                        {
                            movementCoroutine = StartCoroutine(MoveToNextPoint(nextPoint));
                        }
                    }
                    else
                    {
                        rb.velocity = Vector3.zero;
                        isStationary = true;
                    }
                }
            }
            else
            {
                rb.velocity = Vector3.zero;
                isStationary = true;
            }
        }
    }

    private IEnumerator MoveToNextPoint(Vector3 targetPoint)
    {
        Vector3 startPoint = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < secondsMovement)
        {
            rb.MovePosition(Vector3.Lerp(startPoint, targetPoint, elapsedTime / secondsMovement));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(targetPoint); // Ensure we end up exactly at the target point
        rb.velocity = Vector3.zero;
        isStationary = true;
        timerTurn.timer++;
        movementCoroutine = null; // Allow coroutine to start again next time
    }

    void OnDisable()
    {
        deleteDebug.DeleteCircles();
        isStationary = false;
        isDisabled = true;
        if (movementCoroutine != null)
        {
            StopCoroutine(movementCoroutine);
            movementCoroutine = null;
        }
    }

    public void RemotePath()
    {
        path.CreatePath(transform.position, player.position);
        if (path.GetNextPoint(ref nextPoint))
        {
            if (movementCoroutine == null)
            {
                movementCoroutine = StartCoroutine(MoveToNextPoint(nextPoint));
            }
        }
    }
}
