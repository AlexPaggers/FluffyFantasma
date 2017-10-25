using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour {

    private CharacterMovement2D movement2D;

	// Use this for initialization
	void Start ()
    {
        movement2D = GetComponent<CharacterMovement2D>();
	}
	
    void Update()
    {
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
        movement2D.SetGrounded(true);
        Debug.Log("aaaa");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        movement2D.SetGrounded(false);
        Debug.Log("bbbb");
    }

}