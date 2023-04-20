using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeCell cellPrefab;
    [SerializeField] Vector2Int mazeSize;

    private void Start() {
        StartCoroutine(GenerateMaze(mazeSize));
    }

    IEnumerator GenerateMaze(Vector2Int size) {

        List<List<MazeCell>> cellMatrix = new List<List<MazeCell>>();
        List<Vector2Int> unvisitedCoordinates = new List<Vector2Int>();

        for (int y = 0; y < size.y; y++) {
            List<MazeCell> mazeRow = new List<MazeCell>();
            for (int x = 0; x < size.x; x++)
            {
                Vector3 cellPosition = new Vector3(x - (size.x / 2f), -(y - (size.y / 2f)));
                MazeCell newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform);
                mazeRow.Add(newCell);
                unvisitedCoordinates.Add(new Vector2Int(x, y));
                // yield return new WaitForSeconds(0.5f);
            }
            cellMatrix.Add(mazeRow);
        }

        bool isMazeComplete = false;
        List<Vector2Int> spaceStack = new List<Vector2Int>();

        var random = new System.Random();
        while (!isMazeComplete) {
            Vector2Int coordinate;
            MazeCell currentCell;
            if (spaceStack.Count > 0) {
                coordinate = spaceStack[0];
                spaceStack.RemoveAt(0);
            } else if (unvisitedCoordinates.Count > 0) {
                int randomIndex = random.Next(0, unvisitedCoordinates.Count - 1);
                coordinate = unvisitedCoordinates[randomIndex];
                unvisitedCoordinates.RemoveAt(randomIndex);
                spaceStack.Insert(0, coordinate);
                // cellMatrix[coordinate.x][coordinate.y].hideAllWalls();
            } else {
                isMazeComplete = true;
                break;
            }
            currentCell = cellMatrix[coordinate.x][coordinate.y];
            
            // Loop through random neighbor cells
            bool hitDeadEnd = false;
            while (!hitDeadEnd) {
                // Keep a list of all possible directions we haven't tried yet
                List<Direction> possibleNeighborDirections = new List<Direction>{Direction.Left, Direction.Right, Direction.Up, Direction.Down};
                
                // While we have a direction to try, pick one and check its space.
                while (possibleNeighborDirections.Count > 0) {
                    int randomIndex = random.Next(0, possibleNeighborDirections.Count - 1);
                    Direction exitingDirection = possibleNeighborDirections[randomIndex];
                    Direction enteringDirection;
                    possibleNeighborDirections.RemoveAt(randomIndex);
                    
                    Vector2Int newCoordinate = coordinate;
                    switch (exitingDirection)
                    {
                        case Direction.Left:
                            newCoordinate.x--;
                            enteringDirection = Direction.Right;
                            break;
                        case Direction.Right:
                            newCoordinate.x++;
                            enteringDirection = Direction.Left;
                            break;
                        case Direction.Up:
                            newCoordinate.y++;
                            enteringDirection = Direction.Down;
                            break;
                        case Direction.Down:
                            newCoordinate.y--;
                            enteringDirection = Direction.Up;
                            break;
                        default:
                            enteringDirection = Direction.Up;
                            break;
                    }
                    if (unvisitedCoordinates.Contains(newCoordinate)) {
                        // If the space is unvisited, we have a hit!
                        unvisitedCoordinates.Remove(newCoordinate);
                        // let randomNum = random.Next(1, 10);
                        // if (randomNum > 3) {
                            // 70% chance of marking as unblocked.
                            // Continue down this path.
                            spaceStack.Insert(0, newCoordinate);
                            disableWall(currentCell, exitingDirection);
                            disableWall(cellMatrix[newCoordinate.x][newCoordinate.y], enteringDirection);

                            // unblockedCoordinates.insert(neighborCoordinate);
                            coordinate = newCoordinate;
                            break;
                        // } else {
                        //     // 30% chance of marking as blocked.
                        //     // Don't break out of the loop so that we will check other neighboring spaced.
                        //     maze.replaceSpace(at: neighborCoordinate, with: .blocked)
                        // }
                    }
                }
                hitDeadEnd = true;
                yield return new WaitForSeconds(0.1f);
            }
        }
        
        // // Generate a random start and end point
        // guard let startPoint = unblockedCoordinates.randomElement() else {
        //     return maze
        // }
        // unblockedCoordinates.remove(startPoint)
        // maze.startPoint = startPoint
        
        // guard let endPoint = unblockedCoordinates.randomElement() else {
        //     return maze
        // }
        // maze.endPoint = endPoint
        
        yield return null;
    }

    private void disableWall(MazeCell cell, Direction direction) {
        // cell.hideAllWalls();
        switch (direction)
        {
            case Direction.Left:
                cell.hideLeftWall();
                break;
            case Direction.Right:
                cell.hideRightWall();
                break;
            case Direction.Up:
                cell.hideTopWall();
                break;
            case Direction.Down:
                cell.hideBottomWall();
                break;
            default:
                break;
        }
    }
}

enum Direction {
    Up, Down, Left, Right
}