using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidescoll : MonoBehaviour
{
	public GameObject target;
	public float speed = 2;
	public float adjust = 0;
	private Transform current;
	public bool bossRoom = false;


    private GameObject currentRoom;
    private GameObject nextRoom;
    public GameObject roomOne;
    public GameObject roomTwo;



	// Use this for initialization
	void Start ()
	{
        //target the player
        currentRoom = roomOne;
        
    }


    private void Update()
    {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void LateUpdate () 
	{
        if (TrapDoor.TrapDoorHit)
        {
            if(currentRoom == roomOne)
            {
                nextRoom = roomTwo;
            }
            else
            {
                nextRoom = roomOne;
            }
            StartCoroutine(MoveToRoom());
        }




        //set whether in a boss room or not based on gamedata :)
        //if (TrapDoor.TrapDoorHit)
        //{
        //	if (target.transform.position.x > current.position.x + adjust) 
        //    {
        //        var newPosition = Vector3.Lerp(current.position, target.transform.position, speed * Time.deltaTime);
        //        current.position = new Vector3(newPosition.x, current.position.y, current.position.z);
        //		//move towards to the right
        //		//current.position += current.right * speed * Time.deltaTime;
        //	}
        //}
    }


	void Awake()
	{
		current = transform;
	}


    private IEnumerator MoveToRoom()
    {
        while(true)
        {
            var newPosition = Vector3.Lerp(current.position, nextRoom.transform.position, speed * Time.deltaTime);
            current.position = new Vector3(newPosition.x, current.position.y, current.position.z);

            if(Vector2.Distance(transform.position, nextRoom.transform.position) < 0.5f)
            {
                break;
            }

            yield return false;
        }
        currentRoom = nextRoom;
        yield return true;
    }
}
