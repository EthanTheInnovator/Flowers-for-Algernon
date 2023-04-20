using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject topWall;
    [SerializeField] GameObject bottomWall;

    public void hideAllWalls() {
        hideLeftWall();
        hideRightWall();
        hideBottomWall();
        hideTopWall();
    }

    public void hideLeftWall() {
        Destroy(leftWall);
    }

    public void hideRightWall() {
        Destroy(rightWall);
    }

    public void hideTopWall() {
        Destroy(topWall);
    }

    public void hideBottomWall() {
        Destroy(bottomWall);
    }
}
