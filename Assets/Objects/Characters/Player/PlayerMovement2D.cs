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

        Grounded();

    }

   void OnTriggerStay2D(Collider2D col)
   { //
     // if(col.gameObject.tag != "Bullet"
     //     && col.gameObject.tag != "Damaging" 
     //     && col.gameObject.tag != "Room")
     // {
     //     print("Object: " + col.gameObject.name);
     //     movement2D.SetGrounded(true);
     // }
   }

    void OnTriggerExit2D(Collider2D col)
    {
       // if(col.gameObject.tag != "Bullet"
       //     && col.gameObject.tag != "Damaging")            
       // {
       //     print("Trigger Exit");
       //     movement2D.SetGrounded(false);
       // }
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


    private void Grounded()
    {
        var hitAll = Physics2D.RaycastAll(transform.position, Vector2.down);
        foreach(var hit in hitAll)
        {
            if(hit.collider.gameObject.tag == "Player") continue;

            var dist = Vector2.Distance(transform.position, hit.point);
            if(dist > 1f)
            {
                movement2D.SetGrounded(false);
            }
            else
            {
                movement2D.SetGrounded(true);
            }
        }
    }
}

/*        // Raycast grounded test
        float dist = 0f;
        var rayOrigin = new Vector2(transform.position.x, transform.position.y - (sprite.bounds.size.y / 2f));
        var hit = Physics2D.Raycast(rayOrigin, Vector2.down, 0.1f);
        
        Debug.DrawRay(rayOrigin, Vector2.down, Color.yellow);

        // if its not the player update the distance.
        if(hit.collider.gameObject.name != "Player")
        {
            dist = Vector2.Distance(rayOrigin, hit.point);
        }
        print("Distance to ground is " + dist);

        // check the distance to see how far the player is from the floor.
        if(dist > 0.1f)
        {
            // if they are a certain distnace away then they must be off the ground.
            print("Player is off ground");
        }*/
