using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	public GameObject weapon;
	private GameObject target;
	private Transform current;
	float reach;
	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindWithTag("Player");
		reach = GetComponent<SpriteRenderer>().bounds.size.x / 2 + weapon.GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float distance = Vector3.Distance(current.position, target.transform.position);
		if (distance <= reach) 
		{
			SwingWeapon();
			//sound
			//player is hurt by the weapon thing

		}
	}

	private void SwingWeapon()
	{
		//doesn't work but eh
		GetComponentInChildren<Transform>().Rotate(Vector3.up * Time.deltaTime);
		//weapon.transform.Rotate(Vector3.forward * Time.deltaTime);
		//Debug.Log("kapow"); 
	}

	void Awake()
	{
		current = transform;
	
	}
}
