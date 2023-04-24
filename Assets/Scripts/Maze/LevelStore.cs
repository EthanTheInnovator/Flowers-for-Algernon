using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStore : MonoBehaviour
{
    static List<Level> levels = new List<Level> {
        new Level(60, 3, 2, 0, new Vector2Int(5, 5), 1, 1),
        new Level(60, 3, 2, 0, new Vector2Int(6, 6), 2, 2),
        new Level(60, 3, 2.5f, 0, new Vector2Int(7, 7), 3, 3),
        new Level(60, 3, 3, 0, new Vector2Int(8, 8), 4, 4),
        new Level(60, 4, 3, 0, new Vector2Int(10, 5), 5, 1),
        new Level(60, 4, 3, 0.5f, new Vector2Int(10, 10), 6, 2),
        new Level(60, 4, 4, 0.5f, new Vector2Int(12, 9), 7, 2),
        new Level(60, 5, 4, 0.5f, new Vector2Int(13, 10), 8, 2),
        new Level(60, 5, 4, 1f, new Vector2Int(13, 10), 9, 3),
        new Level(60, 5, 4.5f, 1f, new Vector2Int(13, 10), 10, 4),
        new Level(60, 6, 4.5f, 1f, new Vector2Int(13, 10), 11, 5),
    };

    public static Level loadLevel(int levelNumber) {
        return levels[levelNumber];
    }
}
