using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public List<GameObject> liveSprites;
    public Text timer;
    public Text timershadow;

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
        updateTimer();
    }

    void updateLives()
    {
        if (liveSprites[PlayerData.Health].gameObject)
            Destroy(liveSprites[PlayerData.Health].gameObject);
    }

    void updateTimer()
    {
        string minutes = Mathf.Floor(PlayerData.Timer / 60).ToString("00");
        string seconds = Mathf.Floor(PlayerData.Timer % 60).ToString("00");
        timer.text = string.Format("{0}:{1}", minutes, seconds);
        timershadow.text = string.Format("{0}:{1}", minutes, seconds);
    }
}
