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

        List<MazeCell> cells = new List<MazeCell>();

        for (int x = 0; x < size.x; x++) {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 cellPosition = new Vector3(x - (size.x / 2f), y - (size.y / 2f));
                MazeCell newCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform);
                cells.Add(newCell);

                yield return null;
            }
        }

        // List<MazeCell> currentPath = new
    }
}
