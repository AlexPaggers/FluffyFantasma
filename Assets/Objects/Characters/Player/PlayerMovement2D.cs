using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour {

    private SpriteRenderer sprite;

    private CharacterMovement2D movement2D;

    [SerializeField]
    private bool blinking;
    private float timeToFire = 0;
    private float timeToBlink = 0;

    [SerializeField]
    private float blinkTime, blinkSpeed;


	// Use this for initialization
	void Start ()
    {
        movement2D = GetComponent<CharacterMovement2D>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
    void Update()
    {
        if (blinking)
        {
            if (Time.time >= timeToBlink)
            {
                timeToBlink = Time.time + blinkSpeed;
                if (sprite.isVisible == true)
                {
                    sprite.enabled = false;
                }
                else sprite.enabled = true;
            }

            if (Time.time >= timeToFire)
            {
                blinking = false;
                sprite.enabled = true;
            }

           

        }

        if (Input.GetButtonDown("Jump") &&
            movement2D.GetGameType() == CharacterMovement2D.GameType2D.SIDE_SCROLLER)
        {
            movement2D.jump();
        }

        if(movement2D.GetCurrentSpeed().x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (movement2D.GetCurrentSpeed().x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
		if(movement2D.GetGameType() == CharacterMovement2D.GameType2D.SIDE_SCROLLER)
        {
            movement2D.move(new Vector2(Input.GetAxis("Horizontal"), 0));

            if(Input.GetButtonDown("R2"))
            {
                movement2D.SetGameType(CharacterMovement2D.GameType2D.TOP_DOWN_VIEW);
            }
        }

        else if(movement2D.GetGameType() == CharacterMovement2D.GameType2D.TOP_DOWN_VIEW)
        {
            movement2D.move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

            if (Input.GetButtonDown("R2"))
            {
                movement2D.SetGameType(CharacterMovement2D.GameType2D.SIDE_SCROLLER);
            }

        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Bullet"
            && col.gameObject.tag != "Damaging")
        movement2D.SetGrounded(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag != "Bullet"
            && col.gameObject.tag != "Damaging")
            movement2D.SetGrounded(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Damaging" &&
            !blinking)
        {
            blinking = true;
            timeToFire = Time.time + blinkTime;
            PlayerData.inflictDamage();
            //Debug.Log("ouch"); 
        }
    }

}