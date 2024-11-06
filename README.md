# Comparison of Breadth-First Search (BFS) and A* Search Algorithms in Enemy AI Pathfinding 

|    NRP     |      Name      |
| :--------: | :------------: |
| 5025221163 | Muhammad Thariq Darobi |
| 5025221070 | Muhammad Dzaky Taufiqurrahman |
| 5025231068 | Farrell Reynard Jechoniah Simarmata |
| 5025221xxx | Bima |
| 5025231xxx | Haidar |


</div>



## Introduction

Pathfinding is an important component in game development, especially for enemy AI that needs to navigate complex environments. Two commonly used algorithms are Breadth-First Search (BFS) and A* Search. Each search offers its advantages and disadvantages in terms of efficiency, time, and speed. In a large grid environment such as a 64x64, the shortest path results by those algorithms may be different.

Path-finding refers to the concept of finding the shortest route between two distinct points. The concept has been long explored by mathematicians and computer scientists alike, so much so that it has evolved into an entirely separate field of research. This field is heavily based on Dijkstra’s algorithm for pathfinding on weighted paths, where each path takes a certain amount of time, or weight, to traverse. [1](https://kgsea.org/wp-content/uploads/2020/07/Raymond-Kim-BFS-DFS-%E2%80%93-Path-Finding-Algorithms.pdf)

Breadth-first search is a graph traversal algorithm that starts traversing the graph from the root node and explores all the neighboring nodes. Then, it selects the nearest node and explores all the unexplored nodes. While using BFS for traversal, any node in the graph can be considered as the root node. [2](https://www.javatpoint.com/breadth-first-search-algorithm) 

A* Search is an informed best-first search algorithm that efficiently determines the lowest cost path between any two nodes in a directed weighted graph with non-negative edge weights. This algorithm is a variant of Dijkstra’s algorithm. A slight difference arises from the fact that an evaluation function is used to determine which node to explore next. [3](https://www.codecademy.com/resources/docs/ai/search-algorithms/a-star-search) 

Depth First Search (DFS) is an algorithm for exploring a tree or graph by starting at a node and going as deep as possible along each branch before backtracking. It uses a stack to keep track of nodes, either explicitly or through recursion, and is useful in applications like puzzle-solving and pathfinding by fully exploring each path. [4](https://www.javatpoint.com/depth-first-search-algorithm)

The topic that we chose for our final project, is the pathfinding for an enemy to find the player in a made-up video game. In this case, we represent the whole node as a grid 64x64, the root node is the ghost/enemy, and the goal is the player.


## Uniqueness


![image](https://github.com/user-attachments/assets/210142a4-30d2-4d7b-80d4-0b80c306ded5)
Figure 2.0: The Map.

The game we created is a 2-dimensional game with a 64 by 64 grid. The player is portrayed as The Knight who has the objective of finding three keys inside The Dungeon, and finding the way out in the center of The Dungeon.


![image](https://github.com/user-attachments/assets/06e8b3a7-5806-4593-8caa-93366538c82b)
 Figure 2.1: The Knight.


## Background and Problem Statement


In search of the best and shortest search algorithm methodology for an enemy pathfinding in a video game, we try over various different search algorithms (e.g. BFS and A*) to implement an enemy AI pathfinding mechanism and we trace the path traversed by the enemy to find the player. 

![image](https://github.com/user-attachments/assets/c5c5144b-93a5-426a-b693-d321c9f85a75)  
Figure 1.0: Visual representation of the game.

Take this picture as an example, we are wondering which pathfinding algorithm will be the best and shortest to find the path from the ghost/enemy coordinate into the player location while considering the obstacles and tracing the path for the ghost/enemy to traverse. Because the player moves for each turn, the AI will have to adapt to our current position respectively. We also created a power-up for the player to use so that the ghost/enemy teleports back to its original starting point while changing the ghost/enemy search algorithm.

## Methodology

In our final project, we are implementing three commonly known pathfinding algorithms such as: 
Breadth-First Search
A-Star (A*) Search
Depth-First Search

And we are making three comparisons from various environments such as:

Visited Nodes/Time Consumed Comparison from Pathfinding Visualizer.
Path Comparison from 64x64 grid game

After we trace the path of each pathfinding algorithm we implemented in our game, we are able  to make a conclusion that each pathfinding algorithm might result in a different path, especially in a large and complex environment, such as the 64x64 map/grid in our case.

### 1. Visited Nodes/Time Consumed Comparison from Pathfinding Visualizer.


![image](https://github.com/user-attachments/assets/64a858d5-f2bf-4a2c-80d2-8bb0d707800c)

**Breadth-First Search visualization :**

![image](https://github.com/user-attachments/assets/0989304e-2a49-452b-a61c-c8b4beacc3ed)

Figure 2.0: BFS visualization from [Pathfinding Visualizer](https://clementmihailescu.github.io/Pathfinding-Visualizer/#)



</div>



__A-Star (A*) Search visualization :__

![image](https://github.com/user-attachments/assets/24dbd526-a3d2-4dd3-be66-d5771890f9e9)

Figure 2.1: A* Search visualization from [Pathfinding Visualizer](https://clementmihailescu.github.io/Pathfinding-Visualizer/#)


Both BFS and A* Search Shortest-path have the same length but different Visited Node hence the BFS consumes more time because it visits additional nodes by traversing by level.

BFS		: 09.78 Seconds
A* Search	: 03.61 Seconds


### 2. Path Comparison by  64x64 grid game

The pathfinding implemented in this game resulting the ghost being able to chase the player by  using either BFS or A* algorithm based on the power-up user’s consumed 


![image](https://github.com/user-attachments/assets/cea2d915-866a-4644-b32f-1b829d8606ca)
  Figure 3.0: BFS Path.



![image](https://github.com/user-attachments/assets/c942b85f-2d65-4964-be1c-9b4ac25e2f78)
  Figure 3.1: A* Path.



From this comparison, the result of BFS and A* have equal total distances traversed but different paths the ghost takes, this occurs because BFS traverses by its level otherwise A* uses informed search and heuristic value. 

In interactive games and complex environments such as our 64x64 grid game, the paths of the ghost change with every player movement can possibly resulting in the BFS and A* creating a different path even though having the same length, A* generally create the path faster than BFS.

![image](https://github.com/user-attachments/assets/b42914cc-2dc2-4afb-8814-a4b8b948804c)
Figure 3.2: BFS Path.

![image](https://github.com/user-attachments/assets/3fa66e8c-ba2b-4404-a8cb-2d500dce0144)
 Figure 3.3: A* Path.



### 3. Inefficient Pathfinding by Depth-First Search (DFS)

The issue of the enemy moving back and forth occurs because the DFS algorithm can create a path that immediately returns to the previous position. This is typical behavior for DFS, as it explores as far as possible along each branch before backtracking.

To prevent this from happening, we can add a mechanism to remember the previous position and avoid generating a path that immediately returns to that position. In this game’s case, we coded it so that the enemy remembers its last two positions and made it so that it cannot go back to those positions. 

As for another issue, DFS is not suitable for pathfinding because it doesn't search for the shortest path resulting in an inefficient path and longer length ghost/enemy has to traverse 

![image](https://github.com/user-attachments/assets/b6476e9d-0bc1-4ee6-afae-98575907d5bf)
Visual 3.5: Inefficiency of DFS


