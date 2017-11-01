using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidescoll : MonoBehaviour {



	public GameObject target;
	public float speed = 2;
	public float adjust = 0;
	private Transform current;
	public bool bossRoom = false;
	// Use this for initialization
	void Start ()
	{
        //target the player
        
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
		//set whether in a boss room or not based on gamedata :)

		if (!bossRoom)
        {
			if (target.transform.position.x > current.position.x + adjust) 
            {
                var newPosition = Vector3.Lerp(current.position, target.transform.position, speed * Time.deltaTime);
                current.position = new Vector3(newPosition.x, current.position.y, current.position.z);
				//move towards to the right
				//current.position += current.right * speed * Time.deltaTime;
			}
		}
	}


	void Awake()
	{
		current = transform;
	}
}
