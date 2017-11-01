using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	public GameObject weapon;
	private GameObject target;
	private Transform current;
	public float attackTime = 1f;
	public float attackDelay = 2f;
	private float timer = 0f;
	private float reach;
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
		if (distance <= reach && timer == 0) 
		{
			Attack();
			//sound
			//player is hurt by the weapon thing

		}
		if (tag == "Damaging") 
		{
			timer += Time.deltaTime;
			if (timer > attackTime) 
			{
				tag = "Enemy";
				GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
		else if (timer != 0 && timer < attackTime + attackDelay) 
		{
			timer += Time.deltaTime;
		} 
		else 
		{
			timer = 0;
		}
	}

	private void Attack()
	{
		tag = "Damaging";
		GetComponent<SpriteRenderer> ().color = Color.red;

		//Instantiate (weapon, transform.position, Quaternion.identity);
		//doesn't work but eh
		//GetComponentInChildren<Transform>().Rotate(Vector3.up * Time.deltaTime);
		//weapon.transform.Rotate(Vector3.forward * Time.deltaTime);
		Debug.Log("kapow"); 
	}

	void Awake()
	{
		current = transform;
	
	}
}
