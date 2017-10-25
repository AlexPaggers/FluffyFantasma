using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public float tick;
    public Text text;
    public Text shadow;
    public bool hiding;
    int credits;
	// Use this for initialization
	void Start () {
        text.text = "Insert coin to start";
        shadow.text = "Insert coin to start";
        credits = 0;
        hiding = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        tick += Time.deltaTime;
        if (tick > 1)
        {
            tick = 0;
            if(hiding)
            {
                text.enabled = false;
                shadow.enabled = false;
                hiding = false;
            }
            else
            {
                text.enabled = true;
                shadow.enabled = true;
                hiding = true;
            }
            
        }

        if(Input.GetKeyDown("insert"))
        {
            creditInserted();
        }

        if(Input.GetKeyDown("joystick button 8") || Input.GetKeyDown("escape"))
        {
            if (credits > 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}

    void creditInserted()
    {
        credits++;
        text.text = "" + credits + " credit(s). Push start to play";
        shadow.text = "" + credits + " credit(s). Push start to play";
    }

}
