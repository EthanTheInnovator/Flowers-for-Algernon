using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeCell cellPrefab;
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] PlayerController player;

    private void Start() {
        // GenerateMazeInstant(mazeSize);
        GenerateMaze(mazeSize);
    }

    void GenerateMaze(Vector2Int size) {

        List<List<MazeCell>> cellMatrix = new List<List<MazeCell>>();
        List<Vector2Int> unvisitedCoordinates = new List<Vector2Int>();

        for (int y = 0; y < size.y; y++) {
            List<MazeCell> mazeRow = new List<MazeCell>();
            for (int x = 0; x < size.x; x++)
            {
                Vector3 cellPosition = new Vector3(x - (size.x / 2f), y - (size.y / 2f));
                MazeCell newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform);
                mazeRow.Add(newCell);
                unvisitedCoordinates.Add(new Vector2Int(x, y));
            }
            cellMatrix.Add(mazeRow);
        }

        List<Vector2Int> currentPath = new List<Vector2Int>();

        int randomStartIndex = Random.Range(0, unvisitedCoordinates.Count);
        Vector2Int startCoordinate = unvisitedCoordinates[randomStartIndex];
        currentPath.Add(startCoordinate);

        while (unvisitedCoordinates.Count > 0) {
            Vector2Int coordinate = currentPath[currentPath.Count - 1];
            MazeCell currentCell = cellMatrix[coordinate.y][coordinate.x];
            
            // Keep a list of all possible directions we haven't tried yet
            List<Direction> possibleNeighborDirections = new List<Direction>{Direction.Left, Direction.Right, Direction.Up, Direction.Down};
            
            bool foundAvailableNeighbor = false;
            // While we have a direction to try, pick one and check its space.
            while (possibleNeighborDirections.Count > 0) {
                int randomIndex = Random.Range(0, possibleNeighborDirections.Count);
                Direction exitingDirection = possibleNeighborDirections[randomIndex];
                Direction enteringDirection = Direction.Up;
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
                }
                if (unvisitedCoordinates.Contains(newCoordinate) && !currentPath.Contains(newCoordinate)) {
                    // If the space is unvisited, we have a hit!

                    disableWall(currentCell, exitingDirection);
                    disableWall(cellMatrix[newCoordinate.y][newCoordinate.x], enteringDirection);
                    currentPath.Add(newCoordinate);

                    foundAvailableNeighbor = true;
                    break;
                }
            }
            if (!foundAvailableNeighbor) {
                unvisitedCoordinates.Remove(coordinate);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
        
        // // Generate a random start and end point
        int randomEntryPoint = Random.Range(0, mazeSize.x);
        player.transform.position = cellMatrix[0][randomEntryPoint].transform.position;
        
        int randomExitPoint = Random.Range(0, mazeSize.x);
        cellMatrix[mazeSize.y - 1][randomExitPoint].hideTopWall();
        cellMatrix[mazeSize.y - 1][randomExitPoint].setIsExitNode(true);
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