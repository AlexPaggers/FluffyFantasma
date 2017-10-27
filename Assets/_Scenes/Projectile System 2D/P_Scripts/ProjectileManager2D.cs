using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager2D : MonoBehaviour {

    float rot;
    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;

    public Transform bulletPrefab;
    private float timeToFire = 0;
    private Transform firePoint;

    public enum FireType2D
    {
        BURST,
        SINGLE,
        SHOTGUN,
    }

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
        //if (fireRate == 0)
        //{
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        ShootMulti();
        //    }
        //    if (Input.GetKeyDown(KeyCode.UpArrow))
        //    {
        //        ShootMulti();
        //    }
        //}
        //else
        //{
        //    if (Input.GetButton ("Fire1") && Time.time > timeToFire)
        //    {
        //        timeToFire = Time.time + 1 / fireRate;
        //        ShootOne();
        //    }
        //}

        if (Input.GetButton("Fire1") && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
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
        setRotation();
        Effect();
    }

    void ShootMulti()
    {
        setRotation();
        firePoint.rotation = Quaternion.Euler(0.0f, 0.0f, rot);
        Effect();

        firePoint.rotation = Quaternion.Euler(0.0f, 0.0f, rot + 4);
        Effect();

        firePoint.rotation = Quaternion.Euler(0.0f, 0.0f, rot - 4);
        Effect();
    }

    void Effect()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void setRotation()
    {
        //Vector3 Di = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        //Di.Normalize();
        //rot = Mathf.Atan2(Di.y, Di.x) * Mathf.Rad2Deg; //Find the angle

        //rot = Input.GetAxis("Vertical");

    }
}


















//Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
//Vector2 mousePosition2 = new Vector2(mousePosition.x - 0.2f, mousePosition.y - 0.2f);
//Vector2 mousePosition3 = new Vector2(mousePosition.x + 0.1f, mousePosition.y + 0.1f);
//Vector2 mousePosition4 = new Vector2(mousePosition.x - 0.1f, mousePosition.y - 0.1f);

//Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
//RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePosition - firePointPos, 100, whatToHit);

//Debug.DrawLine(firePointPos, (mousePosition - firePointPos) * 100, Color.green);
//Debug.DrawLine(firePointPos, (mousePosition1 - firePointPos) * 100, Color.blue);
//Debug.DrawLine(firePointPos, (mousePosition2 - firePointPos) * 100, Color.yellow);
//Debug.DrawLine(firePointPos, (mousePosition3 - firePointPos) * 100, Color.white);
//Debug.DrawLine(firePointPos, (mousePosition4 - firePointPos) * 100, Color.cyan);

//if (hit.collider != null)
//{
//    Debug.DrawLine(firePointPos, hit.point, Color.red); 
//}