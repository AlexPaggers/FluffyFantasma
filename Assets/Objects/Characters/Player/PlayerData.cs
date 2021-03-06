﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static int lives;
    static float ghostMeter;
    static float timer;
    static bool ghostForm;
    static int health;
    static int maxHealth;
    static int score;



    void Start()
    {
        ghostForm = false;
        maxHealth = 3;
        health = maxHealth;
        lives = GameData.CreditsRemaining;
        score = 0;
        timer = 0;
        ghostMeter = 0;

        if(!PlayerPrefs.HasKey("HighScore")) 
            PlayerPrefs.SetInt("HighScore", 0);
    }

    void Update()
    {
        timer = Time.time;
    }

    public static void inflictDamage()
    {
        if (!ghostForm)
        {
            health--;
            if (health == 0)
            {
                health = 3;
                //DEATH LOGIC -- SOMETHING SIMILAR TO MARIO WOULD BE BANTS
                lives--;
                Debug.Log("No health left! Life lost!");
                if (lives < 0)
                {
                    SceneManager.LoadScene(2);
                    Debug.Log("No lives left! Game over!");
                }
            }
        }
        else
        {
            Debug.Log("Player is in ghost form and cannot be damaged");
        }
    }

    public static void addScore(int _score)
    {
        score += _score;
    }
    public static int Health
    {
        get
        {
            return health;
        }
        set
        {
            value = health;
        }
    }

    public static int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            value = maxHealth;
        }
    }

    public static int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            value = lives;
        }
    }

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            value = score;
        }
    }

    public static float TimeElapsed
    {
        get
        {
            return timer;
        }
        set
        {
            value = timer;
        }
    }

    public static float GhostMeter
    {
        get
        {
            return ghostMeter;
        }
        set
        {
            value = ghostMeter;
        }
    }

    public static void addGhostMeter()
    {
        ghostMeter += 0.01f;
    }

    public static void subGhostMeter()
    {
        ghostMeter -= 0.001f;
    }

    public static float getGhostMeter()
    {
        return ghostMeter;
    }

    public static void setGhostMeter(float _ghostMeter)
    {
        ghostMeter = _ghostMeter;
    }

    public static int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt("HighScore");
        }

        set
        {
            PlayerPrefs.SetInt("HighScore", value);
            PlayerPrefs.Save();
        }
    }
}
