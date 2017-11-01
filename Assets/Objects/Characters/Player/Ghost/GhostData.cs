using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostData : MonoBehaviour {

    private float tempGhostTime = 0;

    [SerializeField]
    private float ghostTime;

    public GameObject filter;

    private bool isGhost;

	// Use this for initialization
	void Start () {
        filter.GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isGhost)
        {

            if(Time.time >= tempGhostTime)
            {
                tempGhostTime = ghostTime + Time.time;
                PlayerData.subGhostMeter();

                
            }

            if (PlayerData.getGhostMeter() <= 0)
            {
                isGhost = false;
                GetComponent<CharacterMovement2D>().SetGameType(CharacterMovement2D.GameType2D.SIDE_SCROLLER);
                PlayerData.setGhostMeter(0);

                filter.GetComponent<SpriteRenderer>().enabled = false;

                GetComponent<Animator>().SetBool("ghost", false);

            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        if(!isGhost && col.gameObject.tag == "GhostOrb")
        {
            Destroy(col.gameObject);
            PlayerData.addGhostMeter();
            PlayerData.addScore(25);
            Debug.Log(PlayerData.GhostMeter);
            
            if(PlayerData.getGhostMeter() >= 1)
            {
                Debug.Log("Ghost transform");
                isGhost = true;
                GetComponent<CharacterMovement2D>().SetGameType(CharacterMovement2D.GameType2D.TOP_DOWN_VIEW);

                

                tempGhostTime = ghostTime + Time.time;
                GetComponent<Animator>().SetBool("ghost", true);
                GetComponent<Animator>().SetBool("walking", false);

                filter.GetComponent<SpriteRenderer>().enabled = true;

            }

        }
    }


}
