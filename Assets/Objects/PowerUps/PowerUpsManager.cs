using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PUTypes
{
    SPEED_INC = 0,
    TRIPLE_SHOOT = 1,
    FOLLOW = 2
}

public class PowerUpsManager : MonoBehaviour {

    public PUTypes pUpType;
	// Use this for initialization
	void Start () { 

        int val = Random.Range(0, 11);

        switch (val)
        {
            case 3:
                pUpType = PUTypes.TRIPLE_SHOOT;
                break;
            case 6:
                pUpType = PUTypes.FOLLOW;
                break;
            default:
                pUpType = PUTypes.SPEED_INC;
                break;
        }

        switch (pUpType)
        {
            case PUTypes.SPEED_INC:
                GetComponent<SpriteRenderer>().color = Color.red;
                //Set Speed Sprite
                break;
            case PUTypes.TRIPLE_SHOOT:
                GetComponent<SpriteRenderer>().color = Color.blue;
                //Set Triple Shoot Sprite
                break;
            case PUTypes.FOLLOW:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                //Set Follow
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
                case PUTypes.SPEED_INC:
                    ProjectileManager2D.incFireRate();
                    //Add extra speed
                    break;
                case PUTypes.TRIPLE_SHOOT:
                    ProjectileManager2D.actTripleShoot();
                    //Set as Shotgun in Gund
                    break;
                case PUTypes.FOLLOW:
                    Projectile2D.followOn();
                    //Set to Follow
                    break;
                default:
                    break;
            }
        }
        Destroy(gameObject);
    }
}
