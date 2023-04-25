using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightMask : MonoBehaviour
{
    [SerializeField] float liveSeconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLiveSeconds(float seconds) {
        liveSeconds = seconds;
    }

    public void beginDestructionCountdown() {
        StartCoroutine("DestroyAfterLiveSeconds");
    }
    
    IEnumerator DestroyAfterLiveSeconds() {
        yield return new WaitForSeconds(liveSeconds);
        Destroy(gameObject);
    }
}
