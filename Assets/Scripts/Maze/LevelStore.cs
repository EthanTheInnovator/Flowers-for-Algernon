using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStore : MonoBehaviour
{
    static List<Level> levels = new List<Level> {
        new Level(30, 3, 2.5f, 0, new Vector2Int(5, 5), 6, 1, 0), // Level 1
        new Level(30, 3, 2.5f, 0, new Vector2Int(6, 6), 6, 2, 0), // Level 2
        new Level(30, 3, 3, 0, new Vector2Int(7, 7), 6, 3, 0), // Level 3
        new Level(45, 3, 3, 0.5f, new Vector2Int(8, 8), 6, 4, 0), // Level 4
        new Level(45, 4, 3, 0.5f, new Vector2Int(10, 5), 6, 1, 0), // Level 5
        new Level(45, 4, 4, 1f, new Vector2Int(9, 9), 6, 2, 0), // Level 6
        new Level(45, 5, 4, 1f, new Vector2Int(12, 9), 6, 2, 0), // Level 7
        new Level(60, 5, 6, 1.5f, new Vector2Int(13, 10), 6, 2, 0), // Level 8
        new Level(60, 6, 6, 1.5f, new Vector2Int(13, 10), 6, 3, 0), // Level 9
        new Level(60, 7, 7f, 2f, new Vector2Int(15, 10), 6, 4, 0), // Level 10 - Should have max stats for everything now
        new Level(60, 7, 7f, 2f, new Vector2Int(15, 10), 6, 5, 1), // Level 11 - REGRESSION POINT
        new Level(60, 7, 7f, 2f, new Vector2Int(15, 10), 6, 6, 2), // Level 12
        new Level(60, 7, 7f, 1.5f, new Vector2Int(15, 10), 6, 7, 3), // Level 13
        new Level(60, 7, 5f, 1.5f, new Vector2Int(15, 10), 6, 8, 4), // Level 14
        new Level(90, 5, 5f, 1.5f, new Vector2Int(15, 10), 6, 9, 5), // Level 15
        new Level(90, 5, 5f, 1f, new Vector2Int(15, 10), 6, 10, 6), // Level 16
        new Level(90, 5, 3f, 1f, new Vector2Int(15, 10), 6, 11, 7), // Level 17
        new Level(90, 3, 3f, 0, new Vector2Int(15, 10), 6, 12, 8), // Level 18
        new Level(90, 3, 3f, 0, new Vector2Int(15, 10), 6, 13, 9), // Level 19
        new Level(300, 1, 2f, 0, new Vector2Int(25, 15), 9.5f, 14, 10), // Level 20
    };

    public static int maxLevels() {
        return levels.Count;
    }

    public static Level loadLevel(int levelNumber) {
        if (levelNumber >= levels.Count) {
            return null;
        }
        return levels[levelNumber];
    }

    public static Level generateLevel() {
        bool shouldLimitViewRadius = Random.Range(0, 10) > 3;
        bool shouldHaveMemory = Random.Range(0, 10) > 7;
        bool shouldHaveAggression = Random.Range(0, 10) > 6;
        return new Level(
            Random.Range(30, 90),
            Random.Range(1, 7),
            shouldLimitViewRadius ? Random.Range(2, 7) : 0,
            shouldHaveMemory ? Random.Range(0, 2) : 0,
            new Vector2Int(Random.Range(3, 15), Random.Range(3, 10)),
            6,
            -1,
            shouldHaveAggression ? Random.Range(0, 10) : 0
        );
    }
}
