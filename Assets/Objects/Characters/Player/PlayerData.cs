using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static int health;
    static int lives;
    static int score;
    static float timer;

    void Start()
    {
        health = 3;
        lives = 3;
        score = 0;
        timer = 0;
    }

    void Update()
    {
        timer = Time.time;
    }

    public static void inflictDamage()
    {
        health--;
        if(health == 0)
        {
            health = 3;
            lives--;
            Debug.Log("No health left! Life lost!");
            if (lives == 0)
            {
                //GAMEOVER LOGIC
                Debug.Log("No lives left! Game over!");
            }
        }
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
            return Score;
        }
        set
        {
            value = Score;
        }
    }

    public static float Timer
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

}
