using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsHittingFloor : MonoBehaviour {

    public ParticleSystem particles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hitr");
        ContactPoint2D contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(particles, pos, rot);
    }

}
