using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    float tick;
    [SerializeField]
    Text text;
    [SerializeField]
    Text shadow;
    [SerializeField]
    Text TEST;


    bool hiding;

    [SerializeField]
    float currentHighscore;

    int credits;
	// Use this for initialization
	void Start () {
        text.text = "Insert coin to start";
        shadow.text = "Insert coin to start";
        readHighscore();
        credits = 0;
        hiding = true;
	}
	

    void readHighscore()
    {

        string path = "Assets/Highscores.txt";

        //Write some text to the test.txt file
        /*StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Highscore: 3700");
        writer.Close();*/

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);

        //Read from the file
        StreamReader reader = new StreamReader(path, true);
        TEST.text = reader.ReadToEnd();


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
