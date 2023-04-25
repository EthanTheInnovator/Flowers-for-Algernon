using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public GameObject pass;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((!pass.activeSelf) && (!lose.activeSelf))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (pause.activeSelf)
                {
                    pause.SetActive(false);
                }
                else
                {
                    pause.SetActive(true);
                }
            }
        }
    }
    public void onButtonClicked() {
        pause.SetActive(false);
    }
}
