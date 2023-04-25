using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static void loadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public static void loadEndlessMode(int currentScore) {
        GameController.levelNumber = currentScore;
        GameController.isEndlessMode = true;
        SceneManager.LoadScene("MazeScene");
    }

    public static void loadLevelScene(int level) {
        GameController.levelNumber = level;
        GameController.isEndlessMode = false;
        SceneManager.LoadScene("MazeScene");
    }
}
