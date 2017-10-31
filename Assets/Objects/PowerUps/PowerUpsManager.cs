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
    public Sprite SpeedSprite;
    public Sprite Trple;
    public Sprite Follow;
	// Use this for initialization
	void Start () { 

        int val = Random.Range(0, 21);

        switch (val)
        {
            case 10:
                pUpType = PUTypes.TRIPLE_SHOOT;
                break;
            case 20:
                pUpType = PUTypes.FOLLOW;
                break;
            default:
                pUpType = PUTypes.SPEED_INC;
                break;
        }

        switch (pUpType)
        {
            case PUTypes.SPEED_INC:
                GetComponent<SpriteRenderer>().sprite = SpeedSprite;
                GetComponent<ParticleSystem>().startColor = Color.red;
                //Set Speed Sprite
                break;
            case PUTypes.TRIPLE_SHOOT:
                GetComponent<SpriteRenderer>().sprite = Trple;
                GetComponent<ParticleSystem>().startColor = Color.cyan;
                //Set Triple Shoot Sprite
                break;
            case PUTypes.FOLLOW:
                GetComponent<SpriteRenderer>().sprite = Follow;
                GetComponent<ParticleSystem>().startColor = Color.yellow;
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
