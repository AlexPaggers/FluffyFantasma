using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static int health;
    static int maxHealth;
    static int lives;
    static int score;
    static float timer;
    static bool ghostForm;

    void Start()
    {
        ghostForm = false;
        maxHealth = 3;
        health = maxHealth;
        lives = GameData.CreditsRemaining;
        score = 0;
        timer = 0;
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
                    //GAMEOVER LOGIC
                    Debug.Log("No lives left! Game over!");
                }
            }
        }
        else
        {
            Debug.Log("Player is in ghost form and cannot be damaged");
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

}
