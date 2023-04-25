using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private SaveDataManager saveDataManager = new SaveDataManager();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startNewGame() {
        saveDataManager.clearAllData();
        SceneLoader.loadLevelScene(0);
    }

    public void loadGame() {
        int lastCompletedLevel = saveDataManager.getLastCompletedLevel();
        if (lastCompletedLevel < 0) {
            lastCompletedLevel = -1;
        }
        SceneLoader.loadLevelScene(lastCompletedLevel + 1);
    }

    public void startEndlessMode() {
        SceneLoader.loadEndlessMode(0);
    }

    public void quitGame() {
        Application.Quit();
    }
}
