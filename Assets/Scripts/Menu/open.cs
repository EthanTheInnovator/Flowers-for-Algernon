using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class open : MonoBehaviour
{
    public GameObject savings;
    public void onButtonClicked() { 
        savings.SetActive(true);
    }
}
