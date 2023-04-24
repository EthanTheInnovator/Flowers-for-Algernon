using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject topWall;
    [SerializeField] GameObject bottomWall;
    [SerializeField] Collider2D goalTrigger;

    bool isExitNode = false;

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

    public void setIsExitNode(bool newValue) {
        isExitNode = newValue;
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.gameObject.name == "Player" && isExitNode) {
            Debug.Log("Win!");
        }
    }
}
