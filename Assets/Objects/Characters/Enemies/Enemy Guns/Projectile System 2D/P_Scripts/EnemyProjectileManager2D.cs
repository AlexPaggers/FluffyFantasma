using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public enum FireType2D
{
    BURST,
    SINGLE,
    SHOTGUN,
}*/
public class EnemyProjectileManager2D : MonoBehaviour {

    public float fireRate = 0;
    public float damage = 10;

    public Transform bulletPrefab;
    //private float timeToFire = 0;
	private float timer = 0;
	private float delay = 0;
   // private float lastRot;
    private Transform firePoint;

    public FireType2D fireType;
    //private FireAngle2D myAngle;

    // Use this for initialization
    void Awake () {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firepoint");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		timer += Time.deltaTime;
		//Debug.Log(timer);
		if (
			//this.transform.root.GetComponent<TrackPlayer>().targetFound &&
			timer > fireRate + delay)
		{
			delay = Random.Range (0f, fireRate / 2);
			timer = 0;

			float displace = EnemyGunController2D.aim;
			float rot = transform.root.transform.rotation.eulerAngles.z + displace;
           // timeToFire = Time.time + 1 / fireRate;
            switch (fireType)
            {

                case FireType2D.SINGLE:
                    {
                        ShootOne(rot);
                        break;
                    }
                case FireType2D.SHOTGUN:
                    {
                        ShootMulti(rot);
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

		//	Debug.Log(rot);
		//	Debug.Log(firePoint.rotation.z);
			//Debug.Log(transform.parent.rotation.z);
			//Debug.Log(transform.root.rotation.z);
        }
	}

	void ShootOne(float rot)
	{
		setRotation(rot);
		Effect();
		Debug.Log("shot");
    }

	void ShootMulti(float rot)
    {
        setRotation(rot - 5f);
        Effect();
        setRotation(rot - 5f);
        Effect();
        setRotation(rot);
		Effect();
		Debug.Log("shots");
        
        //Debug.Log(myAngle);
    }

    void Effect()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void setRotation(float rot)
	{
		Debug.Log(rot);
		firePoint.rotation = Quaternion.Euler(0f, 0f, rot);
		Debug.Log(rot);
		Debug.Log(firePoint.rotation.z);
		//firePoint.rotation.z = rot;
		//Debug.Log(firePoint.rotation.z);
        //lastRot = rot;
    }
}