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
	private float timer = 0;
	private float delay = 0;
    private Transform firePoint;

    public FireType2D fireType;

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

		if (TrackPlayer.getPlayerVisable() == true && timer > fireRate + delay)
		{
			delay = Random.Range (0f, fireRate / 2);
			timer = 0;

			float displace = EnemyGunController2D.aim;
			float rot = transform.root.transform.rotation.eulerAngles.z + displace;

            switch (fireType)
            {

                case FireType2D.SINGLE:
                    {
                        ShootOne(rot);
                        break;
                    }
                default:
                        break;
            }
        }
	}

	void ShootOne(float rot)
	{
		setRotation(rot);
		Effect();
    }

    void Effect()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void setRotation(float rot)
	{
		firePoint.rotation = Quaternion.Euler(0f, 0f, rot);
    }
}