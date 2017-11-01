using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public List<GameObject> liveSprites;

    [SerializeField]
    Image ghostBar;

    [SerializeField]
    Sprite emptyHeart;

    [SerializeField]
    Sprite fullHeart;

    //SpriteRenderer renderer;

    [SerializeField]
    Text score;
    [SerializeField]
    Text scoreShadow;

    [SerializeField]
    Text lives;
    [SerializeField]
    Text livesShadow;

    void Awake()
    {
    }

	// Use this for initialization
	void Start ()
    { 

	}
	
	// Update is called once per frame
	void Update () {
        updateLives();
        updateScore();
        updateHealth();
        updateGhostBar();
    }

    void updateHealth()
    {
        int healthRemaining = 0;

        for(int i = 0; i < PlayerData.MaxHealth; i++)
        {
            if(healthRemaining != PlayerData.Health)
            {
                //liveSprites[i].gameObject.SetActive(true);
                liveSprites[i].gameObject.GetComponent<SpriteRenderer>().sprite = fullHeart;
                healthRemaining++;
            }
            else
            {
                //liveSprites[i].gameObject.SetActive(false);
                liveSprites[i].gameObject.GetComponent<SpriteRenderer>().sprite = emptyHeart;
            }
            
        }
    }

    void updateTimer()
    {
        string minutes = Mathf.Floor(PlayerData.TimeElapsed / 60).ToString("00");
        string seconds = Mathf.Floor(PlayerData.TimeElapsed % 60).ToString("00");
        //timer.text = string.Format("{0}:{1}", minutes, seconds);
        //timerShadow.text = string.Format("{0}:{1}", minutes, seconds);
    }

    void updateScore()
    {
        score.text = PlayerData.Score.ToString("00000");
        scoreShadow.text = PlayerData.Score.ToString("00000");
    }

    void updateLives()
    {
        lives.text = "x" + PlayerData.Lives;
        livesShadow.text = "x" + PlayerData.Lives;
    }

    void updateGhostBar()
    {
        ghostBar.transform.localScale = new Vector3(PlayerData.GhostMeter, ghostBar.transform.localScale.y, ghostBar.transform.localScale.z);
    }
}
