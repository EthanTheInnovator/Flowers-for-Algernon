using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    private bool isLeftWallHidden = false;
    [SerializeField] GameObject leftWall;
    private bool isRightWallHidden = false;
    [SerializeField] GameObject rightWall;
    private bool isTopWallHidden = false;
    [SerializeField] GameObject topWall;
    private bool isBottomWallHidden = false;
    [SerializeField] GameObject bottomWall;
    [SerializeField] Collider2D goalTrigger;

    bool isExitNode = false;

    public void hideAllWalls() {
        hideLeftWall();
        hideRightWall();
        hideBottomWall();
        hideTopWall();
    }

    public bool getIsLeftWallHidden() {
        return isLeftWallHidden;
    }

    public void hideLeftWall() {
        isLeftWallHidden = true;
        Destroy(leftWall);
    }

    public bool getIsRightWallHidden() {
        return isRightWallHidden;
    }

    public void hideRightWall() {
        isRightWallHidden = true;
        Destroy(rightWall);
    }

    public bool getIsTopWallHidden() {
        return isTopWallHidden;
    }

    public void hideTopWall() {
        isTopWallHidden = true;
        Destroy(topWall);
    }

    public bool getIsBottomWallHidden() {
        return isBottomWallHidden;
    }

    public void hideBottomWall() {
        isBottomWallHidden = true;
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
