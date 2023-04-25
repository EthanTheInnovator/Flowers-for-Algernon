using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    [SerializeField] GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameController.togglePause();
            pause.SetActive(gameController.isPaused);
        }
    }
    public void onButtonClicked() {
        gameController.togglePause();
        pause.SetActive(gameController.isPaused);
    }
}
