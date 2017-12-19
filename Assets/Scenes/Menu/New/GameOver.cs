using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    float tick;
    [SerializeField]
    Text text;
    [SerializeField]
    Text shadow;
    [SerializeField]
    Text TEST;
    [SerializeField]
    Text TESTSHADOW;

    bool hiding;

    // Use this for initialization
    void Start()
    {
        text.text = "Insert coin to start";
        shadow.text = "Insert coin to start";
        TEST.text = "Highscore: " + readHighscore();
        TESTSHADOW.text = "Highscore: " + readHighscore();
        hiding = true;
    }


    string readHighscore()
    {
        if (PlayerData.Score > PlayerData.HighScore)
        {
            PlayerData.HighScore = PlayerData.Score;
        }
        return PlayerData.HighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if (tick > 1)
        {
            tick = 0;
            if (hiding)
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

        if (Input.GetKeyDown("joystick button 6") || Input.GetKeyDown("insert"))
        {
            creditInserted();
        }

        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyDown("escape"))
        {
            if (GameData.CreditsRemaining > 0)
                SceneManager.LoadScene(1);
            else
                Debug.Log("No game credits.");
        }
    }

    void creditInserted()
    {
        GameData.insertCredit();
        text.text = "" + GameData.CreditsRemaining + " credit(s) push start to play";
        shadow.text = "" + GameData.CreditsRemaining + " credit(s) push start to play";
    }

}
