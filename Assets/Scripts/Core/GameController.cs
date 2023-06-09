using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class exposes the the game model in the inspector, and ticks the
/// simulation.
/// </summary> 
public class GameController : MonoBehaviour
{   
    public static bool isEndlessMode = false;
    public static int levelNumber = 0;

    public bool isPaused = false;
    [SerializeField] bool overrideLevel;
    [SerializeField] Camera camera;
    [SerializeField] SightMask sightMaskPrefab;
    [SerializeField] PlayerController player;
    [SerializeField] Level level;
    [SerializeField] Maze maze;
    [SerializeField] GameObject blindnessOverlay;
    [SerializeField] Text levelText;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject gameCompleteMenu;
    [SerializeField] GameObject failMenu;
    [SerializeField] Timer timer;

    private SaveDataManager saveDataManager = new SaveDataManager();

    void Start() {
        Time.timeScale = 1;
        if (!overrideLevel) {
            if (!isEndlessMode) {
                level = LevelStore.loadLevel(levelNumber);
            } else {
                level = LevelStore.generateLevel();
            }
        }

        if (isEndlessMode) {
            levelText.text = "LEVEL " + (levelNumber + 1) + "\nHigh Score: " + saveDataManager.getEndlessModeHighScore();
        } else {
            levelText.text = "LEVEL " + (levelNumber + 1);
        }

        camera.orthographicSize = level.cameraSize;
        player.aggression = level.aggression;
        
        blindnessOverlay.SetActive(level.viewRadius > 0);
        player.maxSpeed = level.playerSpeed;
        maze.GenerateNewMaze(level.mazeSize, level.randomSeed);
        timer.timeRemaining = level.timeLimit;

        if (level.memoryLength <= 0) {
            SightMask sightMask = Instantiate(sightMaskPrefab, player.transform.position, Quaternion.identity, player.transform);
            sightMask.transform.localScale = new Vector3(level.viewRadius / player.transform.localScale.x, level.viewRadius / player.transform.localScale.y);
        }
    }
    
    void FixedUpdate()
    {
        if (level.viewRadius > 0) {
            SightMask sightMask = Instantiate(sightMaskPrefab, player.transform.position, Quaternion.identity);
            sightMask.transform.localScale = new Vector3(level.viewRadius, level.viewRadius);
            sightMask.setLiveSeconds(level.memoryLength);
            sightMask.beginDestructionCountdown();
        }
    }

    public void togglePause() {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void timerExpired() {
        Time.timeScale = 0;
        failMenu.SetActive(true);
    }

    public void onPass() {
        if (levelNumber != -1) {
            if (isEndlessMode) {
                if (saveDataManager.getEndlessModeHighScore() < levelNumber + 1) {
                    saveDataManager.setEndlessModeHighScore(levelNumber + 1);
                }
                winMenu.SetActive(true);
            } else if (levelNumber >= LevelStore.maxLevels() - 1) {
                // The player beat the game!
                saveDataManager.setHasCompletedGame(true);
                saveDataManager.setHasUnlockedEndlessMode(true);
                gameCompleteMenu.SetActive(true);
            } else {
                saveDataManager.setLastCompletedLevel(levelNumber);
                winMenu.SetActive(true);
            }
        }
        Time.timeScale = 0;
    }

    public void onExitToMenu() {
        SceneLoader.loadMainMenu();
    }

    public void onReplay() {
        if (isEndlessMode) {
            SceneLoader.loadEndlessMode(0);
        } else {
            SceneLoader.loadLevelScene(levelNumber);
        }
    }

    public void continueToNextLevel() {
        if (isEndlessMode) {
            SceneLoader.loadEndlessMode(levelNumber + 1);
        } else {
            SceneLoader.loadLevelScene(levelNumber + 1);
        }
    }
}
