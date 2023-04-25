using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    public GameObject gameObject;
    public void onButtonClicked() { 
        gameObject.SetActive(false);
    }
}
