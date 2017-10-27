using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController2D : MonoBehaviour {

    public int rotationOffset = 90;

	// Update is called once per frame
	void Update () {

        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //difference.Normalize();

        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Find the an
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

        if(Input.GetAxis("Vertical") == 1 )
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90);

        }

        else if (Input.GetAxis("Vertical") > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 45);
        }

        else if (Input.GetAxis("Vertical") == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 00f);
        }

        //transform.rotation = Quaternion.Euler(0f, 0f, 10 * Input.GetAxis("Vertical"));
        
    }

    public void setOffset(int rot)
    {
        rotationOffset = rot;
    }

    public int getOffset()
    {
        return rotationOffset;
    }
}
