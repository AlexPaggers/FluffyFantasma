using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageTaker : MonoBehaviour {

    [SerializeField]
    private float blinkTime, blinkSpeed;

    private bool blinking;
    private float timeToFire = 0, timeToBlink = 0;

    public float maxHealth;

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (blinking)
        {
            if (Time.time >= timeToBlink)
            {
                timeToBlink = Time.time + blinkSpeed;
                if (sprite.color == Color.white)
                {
                    sprite.color = Color.red;
                }
                else sprite.color = Color.white;
            }

            if (Time.time >= timeToFire)
            {
                blinking = false;
                sprite.color = Color.white;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet" &&
            !blinking)
        {
            blinking = true;
            timeToFire = Time.time + blinkTime;
            Debug.Log("ouch");
        }
    }

}
