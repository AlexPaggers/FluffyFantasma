using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TrapDoor : MonoBehaviour
{
    public Sprite doorOpen;
    public Sprite doorClosed;
    public float trapDoorSpeed = 500f;
    public float timer = 0f;
    public float MAX_TIME = 10f;
    public bool doorLocked = false;
    public bool doorActivated = false;
    public static bool readyToLoad = false;



    private static bool trapDoorHit;
    public static bool TrapDoorHit
    {
        get
        {
            return trapDoorHit;
        }
        
        internal set
        {
            trapDoorHit = value;
        }
    }

    private void Start()
    {
        TrapDoorHit = false;
    }


    private void Update()
    {
        if (doorActivated)
        {
            if (timer <= MAX_TIME)
            {
                timer += Time.deltaTime;
				doorLocked = true;
				GetComponent<ParticleSystem>().enableEmission = false;
            }
            else
            {
                GetComponent<BoxCollider2D>().isTrigger = true;
                GetComponent<SpriteRenderer>().sprite = doorOpen;
                readyToLoad = false;
                doorActivated = false;
				doorLocked = false;
				GetComponent<ParticleSystem>().enableEmission = true;
                timer = 0f;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (doorLocked)
        {
            GetComponent<SpriteRenderer>().sprite = doorClosed;
            GetComponent<BoxCollider2D>().isTrigger = false;
            return;
        }

        if(other.gameObject.tag == "Player")
        {
            TrapDoorHit = true;
            doorActivated = true;
            PushPlayer(other.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TrapDoorHit = false;
        }
    }
	
    private void PushPlayer(Rigidbody2D playerRigidbody)
    {
        var normedVel = playerRigidbody.velocity.normalized * trapDoorSpeed;
        playerRigidbody.AddForce(normedVel);
    }

}
