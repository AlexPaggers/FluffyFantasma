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

    public Transform bulletPrefab;
    private float timeToFire = 0;
    private float lastRot;
    private Transform firePoint;

    public FireType2D fireType;
    private FireAngle2D myAngle;

    public static bool followActive = false;
    public static bool tripleActive = false;
    public static bool multiplier = false;
    // Use this for initialization
    void Awake () {
        fireType = FireType2D.SINGLE;
        fireRate = 10;
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firepoint");
        }
        GetComponent<ParticleSystem>().enableEmission = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (tripleActive != false)
        {
            fireType = FireType2D.SHOTGUN;
            GetComponent<ParticleSystem>().startColor = Color.cyan;
            GetComponent<ParticleSystem>().enableEmission = true;
        }
        if (tripleActive == false && multiplier != true)
        {
            GetComponent<ParticleSystem>().enableEmission = false;
            fireType = FireType2D.SINGLE;
        }
        if (tripleActive == false)
        {
            fireType = FireType2D.SINGLE;
        }
        if ((Input.GetButton("XButton") || Input.GetKeyDown("insert")) && Time.time > timeToFire)
        {
            if (multiplier)
            {
                timeToFire = Time.time + 1 / (fireRate * 2);
                GetComponent<ParticleSystem>().startColor = Color.red;
                GetComponent<ParticleSystem>().enableEmission = true;
            }
            else
            {
                timeToFire = Time.time + 1 / fireRate;
                GetComponent<ParticleSystem>().enableEmission = false;
            }

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

        else if (myAngle == FireAngle2D.DOWN)
        {
            setRotation(275f);
            Effect();
            setRotation(265f);
            Effect();
            setRotation(270f);
            Effect();
        }

        else if (myAngle == FireAngle2D.DDD_RIGHT) //Aiming UP RIGHT
        {
            setRotation(-72.5f);
            Effect();
            setRotation(-62.5f);
            Effect();
            setRotation(-67.5f);
            Effect();
        }

        else if (myAngle == FireAngle2D.DD_RIGHT) //Aiming UP RIGHT
        {
            setRotation(-50f);
            Effect();
            setRotation(-40f);
            Effect();
            setRotation(-45f);
            Effect();
        }

        else if (myAngle == FireAngle2D.D_RIGHT) //Aiming UP RIGHT
        {
            setRotation(-17.5f);
            Effect();
            setRotation(-27.5f);
            Effect();
            setRotation(-22.5f);
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

        else if (myAngle == FireAngle2D.U_RIGHT) //Aiming UP RIGHT
        {
            setRotation(17.5f);
            Effect();
            setRotation(27.5f);
            Effect();
            setRotation(22.5f);
            Effect();
        }

        else if (myAngle == FireAngle2D.UU_RIGHT) //Aiming UP RIGHT
        {
            setRotation(50f);
            Effect();
            setRotation(40f);
            Effect();
            setRotation(45f);
            Effect();
        }

        else if (myAngle == FireAngle2D.UUU_RIGHT) //Aiming UP RIGHT
        {
            setRotation(72.5f);
            Effect();
            setRotation(62.5f);
            Effect();
            setRotation(67.5f);
            Effect();
        }

        else if (myAngle == FireAngle2D.DDD_LEFT) //Aiming LEFT
        {
            setRotation(252.5f);
            Effect();
            setRotation(242.5f);
            Effect();
            setRotation(247.5f);
            Effect();
        }

        else if (myAngle == FireAngle2D.DD_LEFT) //Aiming LEFT
        {
            setRotation(230f);
            Effect();
            setRotation(220f);
            Effect();
            setRotation(225f);
            Effect();
        }

        else if (myAngle == FireAngle2D.D_LEFT) //Aiming LEFT
        {
            setRotation(207.5f);
            Effect();
            setRotation(197.5f);
            Effect();
            setRotation(202.5f);
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

        else if (myAngle == FireAngle2D.U_LEFT) //Aimin UP LEFT
        {
            setRotation(162.5f);
            Effect();
            setRotation(152.5f);
            Effect();
            setRotation(157.5f);
            Effect();
        }

        else if (myAngle == FireAngle2D.UU_LEFT) //Aimin UP LEFT
        {
            setRotation(140f);
            Effect();
            setRotation(130f);
            Effect();
            setRotation(135f);
            Effect();
        }

        else if (myAngle == FireAngle2D.UUU_LEFT) //Aimin UP LEFT
        {
            setRotation(117.5f);
            Effect();
            setRotation(107.5f);
            Effect();
            setRotation(112.5f);
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

    public static bool actFireRate()
    {
        return multiplier = true;
    }
    public static bool disFireRate()
    {
        return multiplier = false;
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