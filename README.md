## Uniqueness

<p align="center">
  <b>Figure 2.0: The Map.</b><br>
  <img src="x" alt="The Map" />
</p>

<p align="justify">
The game we created is a 2-dimensional game with a 64 by 64 grid. The player is portrayed as The Knight who has the objective of finding three keys inside The Dungeon and finding the way out in the center of The Dungeon.
</p>

<p align="center">
  <b>Figure 2.1: The Knight.</b>&nbsp;&nbsp;&nbsp;&nbsp;<b>Figure 2.2: The Ghost.</b><br>
  <img src="x" alt="The Knight" />&nbsp;&nbsp;&nbsp;&nbsp;<img src="x" alt="The Ghost" />
</p>

<p align="justify">
While timing the movement with the acid fountains and also avoiding an enemy that is portrayed as The Ghost, The Player has a choice to take Power-ups. These Power-ups can change the search algorithm of The Ghost. The default is A* Search, while Blue and Green Power-ups change the algorithm into BFS and DFS, respectively.
</p>

<p align="center">
  <b>Figure 2.3: Power-ups.</b><br>
  <img src="x" alt="Power-ups" />
</p>

<p align="justify">
Our project aims to find an efficient and fastest search algorithm for enemy pathfinding by experimenting with various methods while considering time and memory constraints. This setup not only adds complexity with obstructions but also offers a practical application of theoretical concepts by comparing these algorithms and experimenting with them in the enemy AI mechanism.
</p>

---

## Methodology

<p align="justify">
In our final project, we are implementing three commonly known pathfinding algorithms such as:
</p>

- Breadth-First Search (BFS)
- A-Star (A*) Search
- Depth-First Search (DFS)

<p align="justify">
And we are making three comparisons from various environments such as:
</p>

1. Visited Nodes/Time Consumed Comparison in Recursive Division (horizontal-skew) maze
2. Path Comparison from 64x64 grid game
3. Inefficient Pathfinding by Depth-First Search (DFS)

<p align="justify">
After we trace the path of each pathfinding algorithm we implemented in our game and analyze the Pathfinding Visualizer, we can conclude that each pathfinding algorithm might result in a different path, visited node, and speed, especially in a large and complex environment, such as the 64x64 map/grid and Recursive Division (horizontal-skew) maze.
</p>

---

### 1. Visited Nodes/Time Consumed Comparison in Recursive Division (horizontal-skew) maze

<p align="center">
  <b>Figure 3.0: BFS visualization from Pathfinding Visualizer.</b><br>
  <img src="x" alt="BFS Visualization" />
</p>

<p align="center">
  <b>Figure 3.1: A* Search visualization from Pathfinding Visualizer.</b><br>
  <img src="x" alt="A* Visualization" />
</p>

<p align="center">
  <b>Figure 3.2: DFS Search visualization from Pathfinding Visualizer.</b><br>
  <img src="x" alt="DFS Visualization" />
</p>

<p align="justify">
Both BFS and A* Shortest-paths have the same length but different Visited Nodes, hence BFS consumes more time because it visits additional nodes by traversing by level. Meanwhile, DFS does not guarantee the shortest path, making the path length longer compared with BFS and A* because it traverses by depth.
</p>

- BFS: 10.41 Seconds
- A* Search: 04.81 Seconds
- DFS: 17.53 Seconds

---

### 2. Path Comparison on a 64x64 grid game

<p align="justify">
The pathfinding implemented in this game results in the ghost being able to chase the player by using either BFS or A* algorithm, depending on the power-up the user consumes.
</p>

<p align="center">
  <b>Figure 4.0: BFS Path.</b>&nbsp;&nbsp;&nbsp;&nbsp;<b>Figure 4.1: A* Path.</b><br>
  <img src="x" alt="BFS Path" />&nbsp;&nbsp;&nbsp;&nbsp;<img src="x" alt="A* Path" />
</p>

<p align="justify">
From this comparison, the result of BFS and A* shows equal total distances traversed but different paths taken by the ghost. This occurs because BFS traverses by its level, whereas A* uses informed search and heuristic value.
</p>

<p align="justify">
In interactive games and complex environments, such as our 64x64 grid game, the paths of the ghost change with every player movement, possibly resulting in BFS and A* creating different paths even though they have the same length. A* generally creates the path faster than BFS.
</p>

<p align="center">
  <b>Figure 4.2: BFS Path.</b>&nbsp;&nbsp;&nbsp;&nbsp;<b>Figure 4.3: A* Path.</b><br>
  <img src="x" alt="BFS Path" />&nbsp;&nbsp;&nbsp;&nbsp;<img src="x" alt="A* Path" />
</p>

---

### 3. Inefficient Pathfinding by Depth-First Search (DFS)

<p align="justify">
The issue of the enemy moving back and forth occurs because the DFS algorithm can create a path that immediately returns to the previous position. This is typical behavior for DFS, as it explores each branch as far as possible before backtracking.
</p>

<p align="justify">
To prevent this from happening, we can add a mechanism to remember the previous position and avoid generating a path that immediately returns to that position. In this game’s case, we coded it so that the enemy remembers its last two positions and cannot go back to those positions.
</p>

<p align="justify">
Another issue is that DFS is not suitable for pathfinding because DFS does not guarantee getting the shortest path, resulting in an inefficient path and a longer distance the ghost/enemy has to traverse.
</p>

<p align="center">
  <b>Visual 4.4: Inefficiency of DFS.</b><br>
  <img src="x" alt="DFS Inefficiency" />
</p>

---

## Conclusion

<p align="justify">
From our comparison of various environments and search algorithms, we conclude that A-Star is considered the best search algorithm we have tested because it finds the shortest path, with minimum visited nodes, and generally creates a path faster compared to BFS and DFS. The only drawback of A* is that it needs to inform the goal location, with BFS being the second lead and DFS as the third.
</p>
