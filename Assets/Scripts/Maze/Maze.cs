using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] MazeCell cellPrefab;
    [SerializeField] PlayerController player;
    private GameObject container;

    public void GenerateNewMaze(Vector2Int mazeSize, int randomSeed) {
        if (container != null) {
            Destroy(container);
        }
        GameObject newContainer = new GameObject();
        container = Instantiate(newContainer, new Vector3(0f, 0f), Quaternion.identity, transform);

        MazeGenerator generator = new MazeGenerator();
        List<List<MazeNode>> cellMatrix = generator.GenerateMaze(mazeSize, randomSeed);

        for (int y = 0; y < mazeSize.y; y++) {
            for (int x = 0; x < mazeSize.x; x++)
            {
                MazeNode node = cellMatrix[y][x];
                Vector3 cellPosition = new Vector3(x - (mazeSize.x / 2f) + 0.5f, y - (mazeSize.y / 2f) + 0.5f);
                MazeCell newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, container.transform);
                newCell.gameController = this.gameController;
                if (!node.hasTopWall) {
                    newCell.hideTopWall();
                }
                if (!node.hasBottomWall) {
                    newCell.hideBottomWall();
                }
                if (!node.hasLeftWall) {
                    newCell.hideLeftWall();
                }
                if (!node.hasRightWall) {
                    newCell.hideRightWall();
                }
                newCell.setIsExitNode(node.isExitNode);
                if (node.isStartNode) {
                    player.transform.position = newCell.transform.position;
                }
            }
        }
    }
}
