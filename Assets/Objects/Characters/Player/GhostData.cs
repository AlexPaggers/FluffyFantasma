using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostData : MonoBehaviour {

    private float tempGhostTime;

    [SerializeField]
    private float ghostTime;

    private bool isGhost;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (isGhost)
        {

            if(Time.time > tempGhostTime)
            {
                tempGhostTime = ghostTime + Time.time;
            }

            if (PlayerData.GhostMeter == 0)
            {
                isGhost = false;
                GetComponent<CharacterMovement2D>().SetGameType(CharacterMovement2D.GameType2D.SIDE_SCROLLER);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(!isGhost && col.gameObject.name == "GhostOrb")
        {
            Destroy(col.gameObject);
            PlayerData.GhostMeter += 0.01f;
            
            if(PlayerData.GhostMeter == 1)
            {
                isGhost = true;
                GetComponent<CharacterMovement2D>().SetGameType(CharacterMovement2D.GameType2D.TOP_DOWN_VIEW);

                tempGhostTime = ghostTime + Time.time;

            }

        }
    }


}
