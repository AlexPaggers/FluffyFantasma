using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spriteflipper : MonoBehaviour {

	public Sprite right;
	public Sprite left;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.transform.rotation.x < 0) 
		{
			this.GetComponent<SpriteRenderer>().sprite = left;

		} 
		else 
		{
			this.GetComponent<SpriteRenderer>().sprite = right;			
		}
	}
}
