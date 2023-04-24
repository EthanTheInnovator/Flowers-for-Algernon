using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public int timeLimit;
    [SerializeField] public float playerSpeed;
    [SerializeField] public float viewRadius;
    [SerializeField] public float memoryLength;
    [SerializeField] public Vector2Int mazeSize;
    [SerializeField] public int levelNumber;
    [SerializeField] public int randomSeed;

    public Level(int timeLimit, float playerSpeed, float viewRadius, float memoryLength, Vector2Int mazeSize, int levelNumber, int randomSeed)
    {
        this.timeLimit = timeLimit;
        this.playerSpeed = playerSpeed;
        this.viewRadius = viewRadius;
        this.memoryLength = memoryLength;
        this.mazeSize = mazeSize;
        this.levelNumber = levelNumber;
        this.randomSeed = randomSeed;
    }
}
