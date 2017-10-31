using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PUType
{
    SPEED_IN,
    TRIPLE,
    FOLLOW
}

public class PowerUpManager : MonoBehaviour {

    public PUType pUpType;
	// Use this for initialization
	void Start () {
        switch (pUpType)
        {
            case PUType.SPEED_IN:
                //Set Sprite as SPEED INCREASE
                break;
            case PUType.TRIPLE:
                //Set Sprite as TRIPLE SHOOT
                break;
            case PUType.FOLLOW:
                //Set Sprite as FOLLOW
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            switch (pUpType)
            {
                case PUType.SPEED_IN:
                    //Increase SPEED
                    break;
                case PUType.TRIPLE:
                    //Create SHOTGUN
                    break;
                case PUType.FOLLOW:
                    //Bullets FOLLOW
                    break;
                default:
                    break;
            }
        }
    }
}
