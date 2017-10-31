﻿using System.Collections;
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

    private float timeToFollow = 0;
    private float timeToStop = 0;
    private float blinkTime = 5, blinkSpeed = 1;

    private bool following = false;
    private bool tripling = false;
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
        if (following == true)
        {
            if (Time.time >= timeToFollow)
            {
                timeToFollow = Time.time + blinkSpeed;
                Debug.Log("GOING!!");
            }

            if (Time.time >= timeToStop)
            {
                Projectile2D.followOff();
                following = false;
                Destroy(gameObject);
                Debug.Log("STOPPING");
            }
            Debug.Log("FOLLOWING");
        }

        if (tripling == true)
        {
            if (Time.time >= timeToFollow)
            {
                timeToFollow = Time.time + blinkSpeed;
                Debug.Log("GOING!!");
            }

            if (Time.time >= timeToStop)
            {
                ProjectileManager2D.disTripleShoot();
                tripling = false;
                Destroy(gameObject);
                Debug.Log("STOPPING");
            }
            Debug.Log("FOLLOWING");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            switch (pUpType)
            {
                case PUTypes.SPEED_INC:
                    ProjectileManager2D.incFireRate();
                    Destroy(gameObject);
                    //Add extra speed
                    break;
                case PUTypes.TRIPLE_SHOOT:
                    ProjectileManager2D.actTripleShoot();
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<CircleCollider2D>().enabled = false;
                    GetComponent<ParticleSystem>().enableEmission = false;
                    tripling = true;
                    timeToStop = Time.time + (blinkTime * 2);
                    //Set as Shotgun in Gund
                    break;
                case PUTypes.FOLLOW:
                    Projectile2D.followOn();
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<CircleCollider2D>().enabled = false;
                    GetComponent<ParticleSystem>().enableEmission = false;
                    following = true;
                    timeToStop = Time.time + blinkTime;
                    //Set to Follow
                    break;
                default:
                    break;
            }
        }
    }
}
