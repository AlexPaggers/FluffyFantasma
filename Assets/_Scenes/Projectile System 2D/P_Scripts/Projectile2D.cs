using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2D : MonoBehaviour {

    public GameObject target;
    public static bool follow = false;

    public int moveSpeed = 20;
    public float lookDist = 20; //enemies can look at the player (for shooting at them)
    public float moveDist = 10; //objects can move to the player
    private Transform current;

    public float bulletSpeed = 2f;

    void Awake()
    {
        current = transform;
    }
    void Start ()
    {
        //target = GameObject.FindGameObjectWithTag("Damaging");
    }
	// Update is called once per frame
	void Update () {
        if (follow == true)
        {
            target = FindClosestEnemy();
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            current.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.Translate((Vector3.right * Time.deltaTime * bulletSpeed) / 3);
            //current.position += current.right * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.Translate((Vector3.right * Time.deltaTime * bulletSpeed) / 3);
            Destroy(gameObject, 1);
        }
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    public static bool followOn()
    {
        return follow = true;
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Damaging");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
