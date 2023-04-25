using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeNode
{
    public Vector2Int position;
    public bool hasLeftWall = true;
    public bool hasRightWall = true;
    public bool hasTopWall = true;
    public bool hasBottomWall = true;
    public bool isExitNode = false;
    public bool isStartNode = false;

    public MazeNode(Vector2Int position) {
        this.position = position;
    }
}
