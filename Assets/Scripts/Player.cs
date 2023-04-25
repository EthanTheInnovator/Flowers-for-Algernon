using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject pass;
    public GameObject pause;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((!pass.activeSelf )&&(!pause.activeSelf )&&(!lose.activeSelf))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-2 * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(2 * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, 2 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -2 * Time.deltaTime, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Debug.Log("wall hit");
        }
        if (collision.gameObject.tag == "exist") {
            Debug.Log("You pass!");
            pass.SetActive(true);
        }
    }
}
