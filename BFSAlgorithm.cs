using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimplePF2D
{
    public class BFSAlgorithm
    {
        private SimplePathFinding2D pf;
        private Queue<NavNode> queue;
        private Dictionary<NavNode, NavNode> cameFrom;
        private List<Vector3Int> pathPoints;
        private bool pathFound;
        private List<GameObject> debugMarkers;

        public BFSAlgorithm(SimplePathFinding2D newPf)
        {
            pf = newPf;
            queue = new Queue<NavNode>();
            cameFrom = new Dictionary<NavNode, NavNode>();
            pathPoints = new List<Vector3Int>();
            pathFound = false;
            debugMarkers = new List<GameObject>();
        }

        public bool CreatePath(NavNode startNode, NavNode endNode)
        {
            if (startNode == null || endNode == null || startNode.IsIgnorable() || endNode.IsIgnorable())
            {
                return false;
            }

            ClearDebugMarkers();
            queue.Clear();
            cameFrom.Clear();
            pathPoints.Clear();
            pathFound = false;

            queue.Enqueue(startNode);
            cameFrom[startNode] = null;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == endNode)
                {
                    pathFound = true;
                    break;
                }

                foreach (var neighbor in GetNeighbors(current))
                {
                    if (!cameFrom.ContainsKey(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        cameFrom[neighbor] = current;
                    }
                }
            }

            if (pathFound)
            {
                UnpackPath(endNode);
                AddDebugMarkers();
                return true;
            }
            return false;
        }

        private IEnumerable<NavNode> GetNeighbors(NavNode node)
        {
            var directions = new DiagonalDirectionEnum[]
            {
                DiagonalDirectionEnum.Up,
                DiagonalDirectionEnum.Down,
                DiagonalDirectionEnum.Left,
                DiagonalDirectionEnum.Right
            };

            foreach (var dir in directions)
            {
                int offsetX = 0, offsetY = 0;
                Direction.GetOffset(dir, ref offsetX, ref offsetY);
                var neighborPos = new Vector3Int(node.GetIndex().x + offsetX, node.GetIndex().y + offsetY, 0);
                var neighbor = pf.GetNode(neighborPos);

                if (neighbor != null && !neighbor.IsIgnorable())
                {
                    yield return neighbor;
                }
            }
        }

        private void UnpackPath(NavNode endNode)
        {
            var current = endNode;
            while (current != null)
            {
                pathPoints.Add(current.GetIndex());
                current = cameFrom[current];
            }
            pathPoints.Reverse();
        }

        public List<Vector3Int> GetPathPoints()
        {
            return pathPoints;
        }

        public SimplePathFinding2D GetPathFinding()
        {
            return pf;
        }

        private void AddDebugMarkers()
        {
            foreach (var point in pathPoints)
            {
                GameObject marker = Object.Instantiate(pf.DebugMarkerObject, pf.NavToWorld(point), Quaternion.identity);
                debugMarkers.Add(marker);
            }
        }

        private void ClearDebugMarkers()
        {
            foreach (var marker in debugMarkers)
            {
                Object.Destroy(marker);
            }
            debugMarkers.Clear();
        }

        public void RemoveSingleDebugMarker(Vector3 position)
        {
            for (int i = 0; i < debugMarkers.Count; i++)
            {
                if (debugMarkers[i].transform.position == position)
                {
                    Object.Destroy(debugMarkers[i]);
                    debugMarkers.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
