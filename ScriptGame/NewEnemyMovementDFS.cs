using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimplePF2D; // Ensure this namespace is used to access SimplePathFinding2D and DFSAlgorithm

public class NewEnemyMovementDFS : MonoBehaviour
{
    private DFSAlgorithm dfsAlgorithm; // Reference to the DFS algorithm
    private SimplePF2D.Path path; // This will use DFS for pathfinding
    private Rigidbody2D rb;
    private Vector3 nextPoint;
    public bool isStationary = true;
    private Vector3 lastPosition1; // To store the first last position
    private Vector3 lastPosition2; // To store the second last position

    [SerializeField] Transform player;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private TimerTurn timerTurn;
    [SerializeField] private GameObject debugMarkerPrefab;

    public bool isDisabled = true;
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
        SimplePathFinding2D pathfinding = GameObject.Find("GridPathfinding").GetComponent<SimplePathFinding2D>();
        dfsAlgorithm = new DFSAlgorithm(pathfinding, debugMarkerPrefab); // Initialize DFS algorithm
        rb = GetComponent<Rigidbody2D>();
        nextPoint = Vector3.zero;
        lastPosition1 = transform.position; // Initialize lastPosition1
        lastPosition2 = transform.position; // Initialize lastPosition2
        isStationary = true;
        isDisabled = false;
    }

    void Update()
    {
        if (!isDisabled)
        {
            if (timerTurn.timer % 2 == 1 && timerTurn.timer != 0)
            {
                NavNode startNode = dfsAlgorithm.GetPathFinding().GetNode(dfsAlgorithm.GetPathFinding().WorldToNav(transform.position));
                NavNode endNode = dfsAlgorithm.GetPathFinding().GetNode(dfsAlgorithm.GetPathFinding().WorldToNav(player.position));
                NavNode lastNode1 = dfsAlgorithm.GetPathFinding().GetNode(dfsAlgorithm.GetPathFinding().WorldToNav(lastPosition1));
                NavNode lastNode2 = dfsAlgorithm.GetPathFinding().GetNode(dfsAlgorithm.GetPathFinding().WorldToNav(lastPosition2));
                if (dfsAlgorithm.CreatePath(startNode, endNode, lastNode1, lastNode2))
                {
                    path = new SimplePF2D.Path(dfsAlgorithm.GetPathFinding());
                    path.GetPathPointList().AddRange(dfsAlgorithm.GetPathPoints());
                    // The debug path markers are already handled in the DFSAlgorithm class
                }
            }

            if (path != null && path.IsGenerated())
            {
                if (isStationary && timerTurn.timer % 2 == 0)
                {
                    if (path.GetNextPoint(ref nextPoint))
                    {
                        Vector3 direction = (nextPoint - transform.position).normalized;
                        rb.velocity = direction * speed;
                        if (movementCoroutine == null)
                        {
                            movementCoroutine = StartCoroutine(MoveToNextPoint());
                        }
                        isStationary = false;
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

    private IEnumerator MoveToNextPoint()
    {
        Vector3 startPoint = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < secondsMovement)
        {
            rb.MovePosition(Vector3.Lerp(startPoint, nextPoint, elapsedTime / secondsMovement));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(nextPoint); // Ensure we end up exactly at the target point
        rb.velocity = Vector3.zero;
        isStationary = true;
        lastPosition2 = lastPosition1; // Update lastPosition2
        lastPosition1 = transform.position; // Update lastPosition1
        timerTurn.timer++;
        movementCoroutine = null; // Allow coroutine to start again next time
        dfsAlgorithm.RemoveSingleDebugMarker(nextPoint); // Remove the debug marker at this position
    }

    void OnDisable()
    {
        dfsAlgorithm.ClearDebugMarkers(); // Clear all debug markers when the script is disabled
        isStationary = false;
        isDisabled = true;

        if (movementCoroutine != null)
        {
            StopCoroutine(movementCoroutine);
            movementCoroutine = null;
        }
    }
}
