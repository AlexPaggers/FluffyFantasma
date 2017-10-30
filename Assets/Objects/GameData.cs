using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD
    }
    static int credits;
    static float time;
    static bool bossActive;
    static Difficulty difficulty;

    void Start()
    {
        credits = 0;
        bossActive = false;
        difficulty = Difficulty.EASY;
        time = Time.time;
    }

    public static void insertCredit()
    {
        credits++;
    }
    public static int CreditsRemaining
    {
        get
        {
            return credits;
        }
    }

    public static float TimeElapsed
    {
        get
        {
            return time;
        }
    }

    public static bool isBossActive
    {
        get
        {
            return bossActive;
        }
        set
        {
            value = bossActive;
        }
    }
}
