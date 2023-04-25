using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public List<List<MazeNode>> GenerateMaze(Vector2Int mazeSize, int randomSeed) {

        if (randomSeed != -1) {
            Random.InitState(randomSeed);
        }

        List<List<MazeNode>> cellMatrix = new List<List<MazeNode>>();
        List<Vector2Int> unvisitedCoordinates = new List<Vector2Int>();

        for (int y = 0; y < mazeSize.y; y++) {
            List<MazeNode> mazeRow = new List<MazeNode>();
            for (int x = 0; x < mazeSize.x; x++)
            {
                Vector3 cellPosition = new Vector3(x - (mazeSize.x / 2f), y - (mazeSize.y / 2f));
                MazeNode newCell = new MazeNode(new Vector2Int(x, y));
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
            MazeNode currentNode = cellMatrix[coordinate.y][coordinate.x];
            
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

                    disableWall(currentNode, exitingDirection);
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
        cellMatrix[0][randomEntryPoint].isStartNode = true;
        
        int randomExitPoint = Random.Range(0, mazeSize.x);
        cellMatrix[mazeSize.y - 1][randomExitPoint].hasTopWall = false;
        cellMatrix[mazeSize.y - 1][randomExitPoint].isExitNode = true;

        return cellMatrix;
    }

    private void disableWall(MazeNode node, Direction direction) {
        // cell.hideAllWalls();
        switch (direction)
        {
            case Direction.Left:
                node.hasLeftWall = false;
                break;
            case Direction.Right:
                node.hasRightWall = false;
                break;
            case Direction.Up:
                node.hasTopWall = false;
                break;
            case Direction.Down:
                node.hasBottomWall = false;
                break;
            default:
                break;
        }
    }
}

enum Direction {
    Up, Down, Left, Right
}