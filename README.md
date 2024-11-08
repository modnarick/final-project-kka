# Comparison of Search Algorithms in Enemy AI Pathfinding
## <a href="https://drive.google.com/drive/folders/1v15SM0LznL_8jslmJgK4DhrvJzzM8K5d?usp=drive_link">Download the Game Here! </a> 

<table align="center">
  <tr>
    <th style="text-align:center">NRP</th>
    <th style="text-align:center">Name</th>
  </tr>
  <tr>
    <td style="text-align:center">5025221163</td>
    <td style="text-align:center">Muhammad Thariq Darobi</td>
  </tr>
  <tr>
    <td style="text-align:center">5025221070</td>
    <td style="text-align:center">Muhammad Dzaky Taufiqurrahman</td>
  </tr>
  <tr>
    <td style="text-align:center">5025231078</td>
    <td style="text-align:center">Bima Prayoga Miftachul Rahmat</td>
  </tr>
  <tr>
    <td style="text-align:center">5025231068</td>
    <td style="text-align:center">Farrell Reynard Jechoniah Simarmata</td>
  </tr>
  <tr>
    <td style="text-align:center">5025231071</td>
    <td style="text-align:center">Haidar Daffa Firzatullah</td>
  </tr>
</table>

</div>

## Introduction

<p align="justify">
Pathfinding is an important component in game development, especially for enemy AI that needs to navigate complex environments. Two commonly used algorithms are Breadth-First Search (BFS), A-Star (A*) Search, and Depth-First Search. Each search offers its advantages and disadvantages in terms of efficiency, time, and speed. In a large grid environment such as a 64x64, the shortest path results by those algorithms may be different.
</p>

<p align="justify">
Path-finding refers to the concept of finding the shortest route between two distinct points. The concept has been long explored by mathematicians and computer scientists alike, so much so that it has evolved into an entirely separate field of research. This field is heavily based on Dijkstra’s algorithm for pathfinding on weighted paths, where each path takes a certain amount of time, or weight, to traverse. <a href="https://kgsea.org/wp-content/uploads/2020/07/Raymond-Kim-BFS-DFS-%E2%80%93-Path-Finding-Algorithms.pdf">[1]</a>
</p>

<p align="justify">
Breadth-first search is a graph traversal algorithm that starts traversing the graph from the root node and explores all the neighboring nodes. Then, it selects the nearest node and explores all the unexplored nodes. While using BFS for traversal, any node in the graph can be considered as the root node. <a href="https://www.javatpoint.com/breadth-first-search-algorithm">[2]</a>
</p>

<p align="justify">
A* Search is an informed best-first search algorithm that efficiently determines the lowest cost path between any two nodes in a directed weighted graph with non-negative edge weights. This algorithm is a variant of Dijkstra’s algorithm. A slight difference arises from the fact that an evaluation function is used to determine which node to explore next. <a href="https://www.codecademy.com/resources/docs/ai/search-algorithms/a-star-search">[3]</a>
</p>

<p align="justify">
The Depth-First Search or DFS algorithm traverses or explores data structures, such as trees and graphs. The algorithm starts at the root node and examines each branch as far as possible before backtracking. <a href="https://www.javatpoint.com/depth-first-search-algorithm">[4]</a>
</p>

<p align="justify">
The topic that we chose for our final project is the pathfinding for an enemy to find the player in a made-up video game. In this case, we represent the whole node as a grid 64x64, the root node is the ghost/enemy, and the goal is the player.
</p>

## Background and Problem Statement

<p align="justify">
In search of the best and shortest search algorithm methodology for enemy pathfinding in a video game, we try various different search algorithms (e.g. BFS, DFS, & A*) to implement an enemy AI pathfinding mechanism and we trace the path traversed by the enemy to find the player.
</p>

<p align="center">
<img src="https://github.com/user-attachments/assets/af0192cd-e3b9-4ecf-a4a7-b1af0e197281" alt="Figure 1.0: Visual representation of the game" />
</p>

<p align="center">
<b>Figure 1.0: Visual representation of the game.</b>
</p>

<p align="justify">
Take this picture as an example, we are wondering which pathfinding algorithm will be the best and shortest to find the path from the ghost/enemy coordinate into the player location while considering the obstacles and tracing the path for the ghost/enemy to traverse. Because the player moves for each turn, the AI will have to adapt to our current position respectively. We also created power-ups for the player to use to change the enemy’s pathfinding algorithm.
</p>

## Uniqueness

<p align="center">
  <img src="https://github.com/user-attachments/assets/c50558bd-3da5-4a9c-8247-48c47761da36" alt="Figure 2.0: The Map" />
</p>
<p align="center"><b>Figure 2.0: The Map.</b></p>

<p align="justify">
The game we created is a 2-dimensional game with a 64 by 64 grid. The player is portrayed as The Knight who has the objective of finding three keys inside The Dungeon and finding the way out in the center of The Dungeon.
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/366db68b-e058-4fae-a073-cbdc298ce1fd" alt="Figure 2.1: The Knight" width="180" height="180" /> &nbsp;&nbsp;&nbsp;&nbsp;
  <img src="https://github.com/user-attachments/assets/d19813f6-9bd5-488b-aadf-3bd10e0b0fce" alt="Figure 2.2: The Ghost" width="180" height="180" />
</p>
<p align="center"><b>Figure 2.1: The Knight.</b> &nbsp;&nbsp;&nbsp;&nbsp; <b>Figure 2.2: The Ghost.</b></p>


<p align="justify">
While timing the movement with the acid fountains and also avoiding an enemy that is portrayed as The Ghost, The Player has a choice to take Power-ups, these Power-ups can change the search algorithm of The Ghost, the default is A* Search while Blue and Green Power-up changes the algorithm into BFS and DFS respectively.
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/e49725da-62b8-49ad-986c-c5574729e5e1" alt="Figure 2.3: Power-ups" width="180" height="180" /> &nbsp;&nbsp;&nbsp;&nbsp;
  <img src="https://github.com/user-attachments/assets/4710b7de-e8b2-4df1-a30b-1f8fdb5f1513" alt="Figure 2.3: Power-ups" width="180" height="180" />
</p>
<p align="center"><b>Figure 2.3: Power-ups.</b></p>

<p align="justify">
Our project aims to find an efficient and fastest search algorithm for enemy pathfinding by experimenting with various methods while considering time and memory constraints. This setup not only adds complexity with obstructions but also offers a practical application of theoretical concepts. By comparing these algorithms and experimenting them into the enemy AI mechanism.
</p>

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

1. Visited Nodes/Time Consumed Comparison in Recursive Division (horizontal-skew) maze.
2. Path Comparison from 64x64 grid game.
3. Inefficient Pathfinding by Depth-First Search (DFS).

<p align="justify">
After we trace the path of each pathfinding algorithm we implemented in our game and analyze the Pathfinding Visualizer, we are able to conclude that each pathfinding algorithm might result in a different path, visited node, and speed, especially in a large and complex environment, such as the 64x64 map/grid and Recursive Division (horizontal-skew) maze.
</p>


### 1. Visited Nodes/Time Consumed Comparison in Recursive Division (horizontal-skew) maze

<p align="center">
  <a href="https://drive.google.com/file/d/1OsnP3U6bzKimRN4Hh1WhQ_kUau_2bVsk/view?usp=drive_link">
    <img src="https://github.com/user-attachments/assets/6ab00b4f-53ff-46c9-a087-867413176fa1" alt="BFS visualization" />
  </a>
</p>
<p align="center"><b>Click the image to view the BFS visualization video.</b></p>

<p align="center">
  <a href="https://drive.google.com/file/d/1gJjMpItmG43_DgoOWjUNLIUlctP2i476/view?usp=drive_link">
    <img src="https://github.com/user-attachments/assets/aebe019b-0ad7-4991-9a20-985b2d58fa1c" alt="A* Search visualization" />
  </a>
</p>
<p align="center"><b>Click the image to view the A* Search visualization video.</b></p>

<p align="center">
  <a href="https://drive.google.com/file/d/18f4UdHh_d6XK3rRpquPPoigkHXq9No0q/view?usp=drive_link">
    <img src="https://github.com/user-attachments/assets/845f691e-f22a-4c25-91b0-7ee4e54c4f09" alt="DFS Search visualization" />
  </a>
</p>
<p align="center"><b>Click the image to view the DFS Search visualization video.</b></p>

<p align="justify">
Both BFS and A* Shortest-paths have the same length but different Visited Nodes, hence the BFS consumes more time because it visits additional nodes by traversing by level. Meanwhile, DFS does not guarantee the shortest path, making the path length longer compared with BFS and A* because it traverses by depth.

- BFS: 10.41 Seconds
- A* Search: 04.81 Seconds
- DFS: 17.53 Seconds

### 2. Path Comparison on a 64x64 grid game

<p align="justify">
The pathfinding implemented in this game results in the ghost being able to chase the player by using either BFS or A* algorithm based on the power-up the user consumes.
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/ccf718cc-f4c6-4b76-9910-fbce1d67f3c9" alt="Figure 4.0: BFS Path" width="320" height="320" /> &nbsp;&nbsp;&nbsp;&nbsp;
  <img src="https://github.com/user-attachments/assets/1701ddc6-9750-4546-8796-60a98bad6fcc" alt="Figure 4.1: A* Path" width="320" height="320" />
</p>
<p align="center"><b>Figure 4.0: BFS Path.</b> &nbsp;&nbsp;&nbsp;&nbsp; <b>Figure 4.1: A* Path.</b></p>

<p align="justify">
From this comparison, the result of BFS and A* shows equal total distances traversed but different paths taken by the ghost. This occurs because BFS traverses by its level, whereas A* uses informed search and heuristic value.
</p>

<p align="justify">
In interactive games and complex environments, such as our 64x64 grid game, the paths of the ghost change with every player movement, possibly resulting in the BFS and A* creating a different path even though having the same length. A* generally creates the path faster than BFS.
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/412623f1-3079-4256-b51a-246b4785b7ce" alt="Figure 4.2: BFS Path" width="320" height="320" /> &nbsp;&nbsp;&nbsp;&nbsp;
  <img src="https://github.com/user-attachments/assets/f8a4070c-0371-43b3-8b5d-ac4154c16d11" alt="Figure 4.3: A* Path" width="320" height="320" />
</p>
<p align="center"><b>Figure 4.2: BFS Path.</b> &nbsp;&nbsp;&nbsp;&nbsp; <b>Figure 4.3: A* Path.</b></p>

### 3. Inefficient Pathfinding by Depth-First Search (DFS)

<p align="justify">
The issue of the enemy moving back and forth occurs because the DFS algorithm can create a path that immediately returns to the previous position. This is typical behavior for DFS, as it explores each branch as far as possible before backtracking.
</p>

<p align="justify">
To prevent this from happening, we can add a mechanism to remember the previous position and avoid generating a path that immediately returns to that position. In this game’s case, we coded it so that the enemy remembers its last two positions and cannot go back to those positions.
</p>

<p align="justify">
As for another issue, DFS when implemented is not suitable for pathfinding because DFS does not guarantee getting the shortest path, resulting in an inefficient path and longer length the ghost/enemy has to traverse.
</p>

<p align="center">
  <img src="https://github.com/user-attachments/assets/6ebfdb73-fcb3-4370-83c7-6ff9beb0d251" alt="Visual 4.4: Inefficiency of DFS" />
</p>
<p align="center"><b>Visual 4.4: Inefficiency of DFS.</b></p>

## Conclusion

<p align="justify">
From our comparison of various environments and search algorithms, we can conclude that A-Star is considered the best search algorithm we have tested, because it finds the shortest path, with minimum visited nodes, and generally creates a path faster compared with BFS and DFS. The only drawback of A* is that it needs to inform the goal location, with BFS being the second lead and DFS as the third.
</p>

## Reference 

- Kim Raymond. 2020. BFS & DFS – Path Finding Algorithms. Chadwick International School.  
  https://kgsea.org/wp-content/uploads/2020/07/Raymond-Kim-BFS-DFS-%E2%80%93-Path-Finding-Algorithms.pdf

- Javatpoint. (n.d.). Breadth First Search Algorithm.  
  https://www.javatpoint.com/breadth-first-search-algorithm

- TECHBREAUX. 2023. A* Search Algorithm.  
  https://www.codecademy.com/resources/docs/ai/search-algorithms/a-star-search

- A. S. Ravikiran. 2023. DFS Algorithm.  
  https://www.simplilearn.com/tutorials/data-structure-tutorial/dfs-algorithm

- TednesdayGames. 2019. A Tile Pathfinding: Easy Pathfinding for Tiles.  
  https://assetstore.unity.com/packages/tools/behavior-ai/a-tile-pathfinding-easy-pathfinding-for-tiles-136493

- Kenney. (n.d.). Assets.  
  https://kenney.nl/assets

- Mihailescu, C. (n.d.). Pathfinding Visualizer.  
  https://clementmihailescu.github.io/Pathfinding-Visualizer

