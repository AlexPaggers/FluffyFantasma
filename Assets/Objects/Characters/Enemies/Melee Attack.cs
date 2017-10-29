using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	private GameObject target;
	private Transform current;
	float reach;
	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindWithTag("Player");
		reach = GetComponent<SpriteRenderer>().bounds.size.x * 6 / 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float distance = Vector3.Distance(current.position, target.transform.position);
		if (distance <= reach) 
		{
			//animation maybe
			//sound
			//damage player

		}
	}

	void Awake()
	{
		current = transform;
	
	}
}
