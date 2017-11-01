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

    public GameObject mainCamera;
    public GameObject moveToPosition;
    


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

        if (Input.GetButtonDown("Jump") && movement2D.GetGameType() == CharacterMovement2D.GameType2D.SIDE_SCROLLER)
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
    void FixedUpdate()
    {
        if (movement2D.GetGameType() == CharacterMovement2D.GameType2D.SIDE_SCROLLER)
        if(movement2D.GetGameType() == CharacterMovement2D.GameType2D.SIDE_SCROLLER)
        {
            movement2D.move(new Vector2(Input.GetAxis("Horizontal"), 0));

            if (Input.GetButtonDown("R2"))
            {
                movement2D.SetGameType(CharacterMovement2D.GameType2D.TOP_DOWN_VIEW);
            }
        }
        else if(movement2D.GetGameType() == CharacterMovement2D.GameType2D.TOP_DOWN_VIEW)
        {
            movement2D.move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

            if(Input.GetButtonDown("R2"))
            {
                movement2D.SetGameType(CharacterMovement2D.GameType2D.SIDE_SCROLLER);
            }
        }
        Grounded();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Boss Room")
       {
            mainCamera.GetComponent<Sidescoll>().bossRoom = true;
            StartCoroutine(MoveToPosition());
       }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Damaging" &&
            !blinking)
        {
            blinking = true;
            timeToFire = Time.time + blinkTime;
            PlayerData.inflictDamage();
        }
    }

    private IEnumerator MoveToPosition()
    {
        while(true)
        {
            var newPosition = Vector2.Lerp(mainCamera.transform.position, moveToPosition.transform.position, 0.75f * Time.deltaTime);
            mainCamera.transform.position = new Vector3(newPosition.x, mainCamera.transform.position.y, mainCamera.transform.position.z);

            if(Vector2.Distance(mainCamera.transform.position, moveToPosition.transform.position) < 0.75f)
            {
                break;
            }
            yield return false;
        }
        yield return true;
    }


    private void Grounded()
    {
        var hitAll = Physics2D.RaycastAll(transform.position, Vector2.down);
        foreach(var hit in hitAll)
        {
            if(hit.collider.gameObject.tag == "Player") continue;

            print("Hit colliders name: " + hit.collider.gameObject.name);
            var dist = Vector2.Distance(transform.position, hit.point);
            if(dist > 1f)
            {
                movement2D.SetGrounded(false);
            }
            else
            {
                movement2D.SetGrounded(true);
                return;
            }
        }
    }
}