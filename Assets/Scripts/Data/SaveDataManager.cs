using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager
{
    private string lastCompletedLevelKey = "lastCompletedLevel";
    private string hasUnlockedEndlessModeKey = "hasUnlockedEndlessMode";
    private string endlessModeHighScoreKey = "endlessModeHighScore";
    private string hasCompletedGameKey = "hasCompletedGame";

    public SaveDataManager() {}

    public void clearAllData() {
        PlayerPrefs.DeleteAll();
    }

    public int getLastCompletedLevel() {
        return PlayerPrefs.GetInt(lastCompletedLevelKey, -1);
    }

    public void setLastCompletedLevel(int newValue) {
        PlayerPrefs.SetInt(lastCompletedLevelKey, newValue);
    }

    public bool getHasUnlockedEndlessMode() {
        return PlayerPrefs.GetInt(hasUnlockedEndlessModeKey, 0) > 0;
    }

    public void setHasUnlockedEndlessMode(bool newValue) {
        PlayerPrefs.SetInt(hasUnlockedEndlessModeKey, newValue ? 1 : 0);
    }

    public int getEndlessModeHighScore() {
        return PlayerPrefs.GetInt(endlessModeHighScoreKey, 0);
    }

    public void setEndlessModeHighScore(int newValue) {
        PlayerPrefs.SetInt(endlessModeHighScoreKey, newValue);
    }

    public bool getHasCompletedGame() {
        return PlayerPrefs.GetInt(hasCompletedGameKey, 0) > 0;
    }

    public void setHasCompletedGame(bool newValue) {
        PlayerPrefs.SetInt(hasCompletedGameKey, newValue ? 1 : 0);
    }
}
