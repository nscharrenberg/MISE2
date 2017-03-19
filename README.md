# MISE2
MISE2 Stands for Mission Impossible Software Engineering 2, a Top-Down game where you have to beat the enemy and reach the exit to escape from the room.

## Assignment Description
### Game Description
Mission Impossible Software Engineering 2 is a top-down game, where the purpose is to reach the exitpoint on the level. The game contains obstacles such as walls.
To make this game even tougher there are enemies on the field, which are there to prevent you from getting to the exitpoint.
The levels will be randomly generated, and powerups will be added throughout the level.

### Technical Description
The game has to keep track of the position/coordinates and movement (up, down, left, right, standing still) of the characters (player and enemies).
The enemies have the possibility to attack the Player, and possibly eliminate the player when caught to much.

The level contains out of Cells (as in a chestboard). Each level is a square and has a certain width and height.
1 Cell on the level will be marked as "Exit", which is the exitpoint.

The World-Class will manage the game. It generates the level, manages the enemies movement. 
It will periodically update the gameworld to keep track of the latest positions of every entity and to refresh and screen.

## Class Diagram
![classDiagram](Documents/Class%20Diagram.png "MISE2 - Class Diagram")

### Class elucidation
#### World
The main part of the design is the `World` Class. All Communication is going through the `World` Class. 
This class is primarilty responsible for updating and generating the current gamestate. The `Update` method makes sure that the `Player` and `Enemy` can update their status.
This also goes for the `DrawX` &#x1F53C; Class.

#### Levels & Cells
The `Level` is a square.
The `levelSize` contains the size (width & height) of the level.
The `cellSize` contains de size (width & height) of each individual cell. `cellCount` count all the cell's combined in both directions. (x and y)
The `exitPoint` is the exitpoint, and in other words, the point you have to reach in order to win the game. The reason for not returning the Cell but returning a position (Point) has to do with the part where it does not have dependencies to the `Cell` class. 
So only the `Level` Class uses it. This should make it less complicated and easier to keep the classes updated properly.

The `Cell` Class is made to define a certain type to a `Cell` and remember those coordinates, position (which cell), and Type (Normal/Empty, Wall or Exit/Finish).
The `Cell` Class has a `coordinates` attribute, which keeps track which cell it is. It saves the points of the bottom left of the cell square, and it will help the `cellPosition` attribute to know to coordinates in pixels.

The `Enemy` spawns in at a random position on the map. This can't be on the `Player` or on a `Wall` but has to be on an empty space. 
The `CheckFreePosition` method checks for a free position and makes sure the enemy will be spawned only on `Empty` Spaces.
The `Player` and `Enemy` shouldn't walk through a wall, and should be blocked when it runs into a wall. The method `CheckCellTypeAtPosition` checks if the `cellType` is a wall, and if so it'll not let the `Player` or `Enemy` walk there and remain on the same cell.

#### Gameplay
The `Player` and `Enemy` Class have certain things in common such as the `position` and `hitpoint` attributes.
The Main Form needs to get info to what the `Player` and `Enemy` need and/or are current doing.
The `movePlayer` indicates the movement of the `Player` when a certain key is pressed.

#### enumerations
The game has 2 enumerations named `CellType` and `MovementType`. 
The `CellType` is being used by the `Cell` class to define a certain type to each cell (Normal/Empty, Wall, Exit/Finish).
The `MovementType` is being used by the `Character` which is an inheritance of `Enemy` and `Player` classes to explicitly tell the movements of the characters.

---
&#x1F53C; the X in DrawX stands for the Class name. e.g. DrawWorld, DrawCharacter, DrawCell
