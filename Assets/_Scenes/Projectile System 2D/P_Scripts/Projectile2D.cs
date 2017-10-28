using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2D : MonoBehaviour {

    public float bulletSpeed = 2f;

	// Update is called once per frame
	void Update () {
        transform.Translate((Vector3.right * Time.deltaTime * bulletSpeed)/3);
        Destroy(gameObject, 1);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

}
