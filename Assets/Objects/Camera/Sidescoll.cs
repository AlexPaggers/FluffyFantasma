using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidescoll : MonoBehaviour {



	public GameObject target;
	public float speed = 2;
	public float adjust = 0;
	private Transform current;
	private bool bossRoom = false;
	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindWithTag("Player"); //target the player

	}
	
	// Update is called once per frame
	void Update () 
	{

		//set whether in a boss room or not based on gamedata :)

		if (!bossRoom) {
			if (target.transform.position.x > current.position.x + adjust) {
				//move towards to the right
				current.position += current.right * speed * Time.deltaTime;
			}
		}
	}


	void Awake()
	{
		current = transform;
	}
}
