using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour {


	public GameObject target;
	//public Transform target;
	public float moveSpeed = 3;
	//public float rotSpeed = 3;
	public float lookDist = 20; //enemies can look at the player (for shooting at them)
	public float moveDist = 10; //objects can move to the player
	public float stopDist = 0; //objects stop a certain distance from the player
	public bool targetFound = false;
	private Transform current;



	// Use this for initialization
	void Start () {
		//without this line script could be used for tracking to other things
		target = GameObject.FindWithTag("Player"); //target the player
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float distance = Vector3.Distance(current.position, target.transform.position);
		if (distance <= lookDist)
		{
			targetFound = true;
			//rotate to look at the player
			Vector3 dir = target.transform.position - transform.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			current.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

			//current.rotation = Quaternion.Slerp(current.rotation,
			//	Quaternion.LookRotation(target.transform.position - current.position), rotSpeed*Time.deltaTime);
			if (distance <= moveDist && distance > stopDist)
			{
				//move towards the player=
				current.position += current.right * moveSpeed * Time.deltaTime;
			}
		} 
		else 
		{
			targetFound = false;
		}

	}

	void Awake()
	{
		current = transform;
	}


}
