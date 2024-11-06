# Comparison of Breadth-First Search (BFS) and A* Search Algorithms in Enemy AI Pathfinding 

|    NRP     |      Name      |
| :--------: | :------------: |
| 5025221163 | Muhammad Thariq Darobi |
| 5025221070 | Muhammad Dzaky Taufiqurrahman |
| 5025231068 | Farrell Reynard Jechoniah Simarmata |
| 5025231078 | Bima Prayoga Miftachul Rahma |
| 5025231xxx | Anggota 5 |

## Introduction

Pathfinding is an important component in game development, especially for enemy AI that needs to navigate complex environments. Two commonly used algorithms are Breadth-First Search (BFS), A-Star (A*) Search, and Depth-First Search (DFS). Each search offers its advantages and disadvantages in terms of efficiency, time, and speed. In a large grid environment such as a 64x64, the shortest path results by those algorithms may be different.

Pathfinding refers to the concept of finding the shortest route between two distinct points. The concept has been long explored by mathematicians and computer scientists alike, so much so that it has evolved into an entirely separate field of research. This field is heavily based on Dijkstra’s algorithm for pathfinding on weighted paths, where each path takes a certain amount of time, or weight, to traverse. [1]

Breadth-first search is a graph traversal algorithm that starts traversing the graph from the root node and explores all the neighboring nodes. Then, it selects the nearest node and explores all the unexplored nodes. While using BFS for traversal, any node in the graph can be considered as the root node. [2]

A* Search is an informed best-first search algorithm that efficiently determines the lowest cost path between any two nodes in a directed weighted graph with non-negative edge weights. This algorithm is a variant of Dijkstra’s algorithm. A slight difference arises from the fact that an evaluation function is used to determine which node to explore next. [3]

The Depth-First Search or DFS algorithm traverses or explores data structures, such as trees and graphs. The algorithm starts at the root node and examines each branch as far as possible before backtracking. [4]

The topic that we chose for our final project is the pathfinding for an enemy to find the player in a made-up video game. In this case, we represent the whole node as a grid 64x64, the root node is the ghost/enemy, and the goal is the player.

## Background and Problem Statement

In search of the best and shortest search algorithm methodology for enemy pathfinding in a video game, we try various different search algorithms (e.g. BFS, DFS, & A*) to implement an enemy AI pathfinding mechanism and we trace the path traversed by the enemy to find the player.

![Figure 1.0: Visual representation of the game](https://github.com/user-attachments/assets/af0192cd-e3b9-4ecf-a4a7-b1af0e197281)
**Figure 1.0: Visual representation of the game.**

Take this picture as an example, we are wondering which pathfinding algorithm will be the best and shortest to find the path from the ghost/enemy coordinate into the player location while considering the obstacles and tracing the path for the ghost/enemy to traverse. Because the player moves for each turn, the AI will have to adapt to our current position respectively. We also created power-ups for the player to use to change the enemy’s pathfinding algorithm.

## Uniqueness

![The Map](x)
**Figure 2.0: The Map.**

The game we created is a 2-dimensional game with a 64 by 64 grid. The player is portrayed as The Knight who has the objective of finding three keys inside The Dungeon and finding the way out in the center of The Dungeon.

![The Knight](x)&nbsp;&nbsp;&nbsp;&nbsp;![The Ghost](x)  
**Figure 2.1: The Knight.**&nbsp;&nbsp;&nbsp;&nbsp;**Figure 2.2: The Ghost.**

While timing the movement with the acid fountains and also avoiding an enemy that is portrayed as The Ghost, The Player has a choice to take Power-ups. These Power-ups can change the search algorithm of The Ghost. The default is A* Search, while Blue and Green Power-ups change the algorithm into BFS and DFS, respectively.

**Figure 2.3: Power-ups.**  
![Power-ups](x)

Our project aims to find an efficient and fastest search algorithm for enemy pathfinding by experimenting with various methods while considering time and memory constraints. This setup not only adds complexity with obstructions but also offers a practical application of theoretical concepts by comparing these algorithms and experimenting with them in the enemy AI mechanism.

---

## Methodology

In our final project, we are implementing three commonly known pathfinding algorithms such as:

- Breadth-First Search (BFS)
- A-Star (A*) Search
- Depth-First Search (DFS)

And we are making three comparisons from various environments such as:

1. Visited Nodes/Time Consumed Comparison in Recursive Division (horizontal-skew) maze
2. Path Comparison from 64x64 grid game
3. Inefficient Pathfinding by Depth-First Search (DFS)

After we trace the path of each pathfinding algorithm we implemented in our game and analyze the Pathfinding Visualizer, we can conclude that each pathfinding algorithm might result in a different path, visited node, and speed, especially in a large and complex environment, such as the 64x64 map/grid and Recursive Division (horizontal-skew) maze.

---

### 1. Visited Nodes/Time Consumed Comparison in Recursive Division (horizontal-skew) maze

![BFS Visualization](x)  
**Figure 3.0: BFS visualization from Pathfinding Visualizer.**

![A* Visualization](x)  
**Figure 3.1: A* Search visualization from Pathfinding Visualizer.**

![DFS Visualization](x)  
**Figure 3.2: DFS Search visualization from Pathfinding Visualizer.**

Both BFS and A* Shortest-paths have the same length but different Visited Nodes, hence BFS consumes more time because it visits additional nodes by traversing by level. Meanwhile, DFS does not guarantee the shortest path, making the path length longer compared with BFS and A* because it traverses by depth.

- BFS: 10.41 Seconds
- A* Search: 04.81 Seconds
- DFS: 17.53 Seconds

---

### 2. Path Comparison on a 64x64 grid game

The pathfinding implemented in this game results in the ghost being able to chase the player by using either BFS or A* algorithm, depending on the power-up the user consumes.

![BFS Path](x)&nbsp;&nbsp;&nbsp;&nbsp;![A* Path](x)  
**Figure 4.0: BFS Path.**&nbsp;&nbsp;&nbsp;&nbsp;**Figure 4.1: A* Path.**

From this comparison, the result of BFS and A* shows equal total distances traversed but different paths taken by the ghost. This occurs because BFS traverses by its level, whereas A* uses informed search and heuristic value.

In interactive games and complex environments, such as our 64x64 grid game, the paths of the ghost change with every player movement, possibly resulting in BFS and A* creating different paths even though they have the same length. A* generally creates the path faster than BFS.

![BFS Path](x)&nbsp;&nbsp;&nbsp;&nbsp;![A* Path](x)  
**Figure 4.2: BFS Path.**&nbsp;&nbsp;&nbsp;&nbsp;**Figure 4.3: A* Path.**

---

### 3. Inefficient Pathfinding by Depth-First Search (DFS)

The issue of the enemy moving back and forth occurs because the DFS algorithm can create a path that immediately returns to the previous position. This is typical behavior for DFS, as it explores each branch as far as possible before backtracking.

To prevent this from happening, we can add a mechanism to remember the previous position and avoid generating a path that immediately returns to that position. In this game’s case, we coded it so that the enemy remembers its last two positions and cannot go back to those positions.

Another issue is that DFS is not suitable for pathfinding because DFS does not guarantee getting the shortest path, resulting in an inefficient path and a longer distance the ghost/enemy has to traverse.

**Visual 4.4: Inefficiency of DFS.**  
![DFS Inefficiency](x)

---

## Conclusion

From our comparison of various environments and search algorithms, we conclude that A-Star is considered the best search algorithm we have tested because it finds the shortest path, with minimum visited nodes, and generally creates a path faster compared to BFS and DFS. The only drawback of A* is that it needs to inform the goal location, with BFS being the second lead and DFS as the third.
