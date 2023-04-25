using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveDataManager;
using NUnit.Framework;

public class SaveDataManagerTests {

    SaveDataManager saveDataManager;

    [SetUp]
    public void SetUp() {
        saveDataManager = new SaveDataManager();
    }

    [TearDown]
    public void TearDown() {
        saveDataManager.clearAllData();
        saveDataManager = null;
    }
    
    [Test]
    public void TestLastCompletedLevel() {
        int defaultValue = saveDataManager.getLastCompletedLevel();
        Assert.AreEqual(defaultValue, -1);
        int newValue = 4;
        saveDataManager.setLastCompletedLevel(newValue);
        int savedValue = saveDataManager.getLastCompletedLevel();
        Assert.AreEqual(savedValue, newValue);
    }

    [Test]
    public void TestHasUnlockedEndlessMode() {
        bool defaultValue = saveDataManager.getHasUnlockedEndlessMode();
        Assert.AreEqual(defaultValue, false);
        bool newValue = true;
        saveDataManager.setHasUnlockedEndlessMode(newValue);
        bool savedValue = saveDataManager.getHasUnlockedEndlessMode();
        Assert.AreEqual(savedValue, newValue);
    }

    [Test]
    public void TestEndlessModeHighScore() {
        int defaultValue = saveDataManager.getEndlessModeHighScore();
        Assert.AreEqual(defaultValue, 0);
        int newValue = 7;
        saveDataManager.setEndlessModeHighScore(newValue);
        int savedValue = saveDataManager.getEndlessModeHighScore();
        Assert.AreEqual(savedValue, newValue);
    }

    [Test]
    public void TestHasCompletedGame() {
        bool defaultValue = saveDataManager.getHasCompletedGame();
        Assert.AreEqual(defaultValue, false);
        bool newValue = true;
        saveDataManager.setHasCompletedGame(newValue);
        bool savedValue = saveDataManager.getHasCompletedGame();
        Assert.AreEqual(savedValue, newValue);
    }
}
