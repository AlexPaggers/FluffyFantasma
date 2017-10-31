using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireType2D
{
    BURST,
    SINGLE,
    SHOTGUN,
}
public class ProjectileManager2D : MonoBehaviour {

    public float fireRate = 0;
    public float damage = 10;
    private static float multiplier = 0.25f;

    public Transform bulletPrefab;
    private float timeToFire = 0;
    private float lastRot;
    private Transform firePoint;

    public FireType2D fireType;
    private FireAngle2D myAngle;

    public static bool followActive = false;
    public static bool tripleActive = false;
    // Use this for initialization
    void Awake () {
        fireType = FireType2D.SINGLE;
        fireRate = 4;
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firepoint");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (tripleActive != false)
        {
            fireType = FireType2D.SHOTGUN;
        }
        if (tripleActive == false)
        {
            fireType = FireType2D.SINGLE;
        }
		if ((Input.GetButton("XButton") || Input.GetKeyDown("insert")) && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / (fireRate * multiplier);
            switch (fireType)
            {
                case FireType2D.SINGLE:
                    {
                        ShootOne();
                        break;
                    }
                case FireType2D.SHOTGUN:
                    {
                        ShootMulti();
                        break;
                    }
                case FireType2D.BURST:
                    {

                        break;
                    }
                default:
                    {

                        break;
                    }
            }

        }

	}

    void ShootOne()
    {
        Effect();
    }

    void ShootMulti()
    {
        myAngle = GunController2D.fireAngle;
        if (myAngle == FireAngle2D.UP)
        {
            setRotation(95f);
            Effect();
            setRotation(85f);
            Effect();
            setRotation(90f);
            Effect();
        }

        else if (myAngle == FireAngle2D.UP_RIGHT) //Aiming UP RIGHT
        {
            setRotation(50f);
            Effect();
            setRotation(40f);
            Effect();
            setRotation(45f);
            Effect();
        }

        else if (myAngle == FireAngle2D.UP_LEFT) //Aimin UP LEFT
        {
            setRotation(140f);
            Effect();
            setRotation(130f);
            Effect();
            setRotation(135f);
            Effect();
        }

        else if (myAngle == FireAngle2D.RIGHT) //Aiming RIGHT
        {
            setRotation(5f);
            Effect();
            setRotation(-5f);
            Effect();
            setRotation(0f);
            Effect();
        }

        else if (myAngle == FireAngle2D.LEFT) //Aiming LEFT
        {
            setRotation(185f);
            Effect();
            setRotation(175f);
            Effect();
            setRotation(180f);
            Effect();
        }
        else
        {
            setRotation(lastRot + 5f);
            Effect();
            setRotation(lastRot - 5f);
            Effect();
            setRotation(lastRot);
            Effect();
        }
        //Debug.Log(myAngle);
    }

    void Effect()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void setRotation(float rot)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rot);
        lastRot = rot;
    }

    public static void incFireRate()
    {
        multiplier += multiplier;
    }

    public static bool actTripleShoot()
    {
        return tripleActive = true;
    }
    public static bool disTripleShoot()
    {
        return tripleActive = false;
    }
}