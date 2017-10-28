using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FireAngle2D
{
    LEFT,
    UP_LEFT,
    UP,
    UP_RIGHT,
    RIGHT
}
public class GunController2D : MonoBehaviour
{

    public int rotationOffset = 90;
    public static FireAngle2D fireAngle;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Vertical") == 1) //Aiming UP
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            fireAngle = FireAngle2D.UP;
            //Debug.Log("UP");
        }

        else if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0) //Aiming UP RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 45f);
            fireAngle = FireAngle2D.UP_RIGHT;
            //Debug.Log("U_RIGHT");
        }

        else if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0)  //Aimin UP LEFT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 135f);
            fireAngle = FireAngle2D.UP_LEFT;
            //Debug.Log("U_LEFT");
        }

        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") > 0) //Aiming RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            fireAngle = FireAngle2D.RIGHT;
            //Debug.Log("RIGHT");
        }

        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") < 0) //Aiming LEFT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            fireAngle = FireAngle2D.LEFT;
            //Debug.Log("LEFT");
        }
    }

    public void setOffset(int rot)
    {
        rotationOffset = rot;
    }

    public int getOffset()
    {
        return rotationOffset;
    }

    public FireAngle2D getAngle()
    {
        return fireAngle;
    }
}
