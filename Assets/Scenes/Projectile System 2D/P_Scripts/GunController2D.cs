using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FireAngle2D
{
    DD_LEFT,
    D_LEFT,
    LEFT,
    U_LEFT,
    UU_LEFT,
    UUU_LEFT,
    UP,
    UUU_RIGHT,
    UU_RIGHT,
    U_RIGHT,
    RIGHT,
    D_RIGHT,
    DD_RIGHT
}
public class GunController2D : MonoBehaviour
{

    public int rotationOffset = 90;
    public static FireAngle2D fireAngle;


    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (Input.GetAxis("Vertical") == 1) //Aiming UP
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            fireAngle = FireAngle2D.UP;
            //Debug.Log("UP");
        }

        else if ((Input.GetAxis("Vertical") < -0.25 && Input.GetAxis("Vertical") >= -0.50) && Input.GetAxis("Horizontal") > 0) //Aiming RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -45f);
            fireAngle = FireAngle2D.DD_RIGHT;
            //Debug.Log("RIGHT");
        }

        else if ((Input.GetAxis("Vertical") < 0 && Input.GetAxis("Vertical") >= -0.25) && Input.GetAxis("Horizontal") > 0) //Aiming RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -22.5f);
            fireAngle = FireAngle2D.D_RIGHT;
            //Debug.Log("RIGHT");
        }

        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") > 0) //Aiming RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            fireAngle = FireAngle2D.RIGHT;
            //Debug.Log("RIGHT");
        }

        else if ((Input.GetAxis("Vertical") >= 0 && Input.GetAxis("Vertical") <= 0.25) && Input.GetAxis("Horizontal") > 0) //Aiming UP RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 22.5f);
            fireAngle = FireAngle2D.U_RIGHT;
            //Debug.Log("U_RIGHT");
        }

        else if ((Input.GetAxis("Vertical") > 0.25 && Input.GetAxis("Vertical") <= 0.50) && Input.GetAxis("Horizontal") > 0) //Aiming UP RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 45f);
            fireAngle = FireAngle2D.UU_RIGHT;
            //Debug.Log("U_RIGHT");
        }

        else if ((Input.GetAxis("Vertical") > 0.50 && Input.GetAxis("Vertical") < 1) && Input.GetAxis("Horizontal") > 0) //Aiming UP RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 67.5f);
            fireAngle = FireAngle2D.UUU_RIGHT;
            //Debug.Log("U_RIGHT");
        }

        else if ((Input.GetAxis("Vertical") < -0.25 && Input.GetAxis("Vertical") >= -0.50) && Input.GetAxis("Horizontal") < 0) //Aiming RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 225f);
            fireAngle = FireAngle2D.DD_LEFT;
            //Debug.Log("RIGHT");
        }

        else if ((Input.GetAxis("Vertical") < 0 && Input.GetAxis("Vertical") >= -0.25) && Input.GetAxis("Horizontal") < 0) //Aiming RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 202.5f);
            fireAngle = FireAngle2D.D_LEFT;
            //Debug.Log("RIGHT");
        }

        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") < 0) //Aiming LEFT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            fireAngle = FireAngle2D.LEFT;
            //Debug.Log("LEFT");
        }

        else if ((Input.GetAxis("Vertical") >= 0 && Input.GetAxis("Vertical") <= 0.25) && Input.GetAxis("Horizontal") < 0) //Aiming UP RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 157.5f);
            fireAngle = FireAngle2D.U_LEFT;
            //Debug.Log("U_RIGHT");
        }

        else if ((Input.GetAxis("Vertical") > 0.25 && Input.GetAxis("Vertical") <= 0.50) && Input.GetAxis("Horizontal") < 0) //Aiming UP RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 135f);
            fireAngle = FireAngle2D.UU_LEFT;
            //Debug.Log("U_RIGHT");
        }

        else if ((Input.GetAxis("Vertical") > 0.50 && Input.GetAxis("Vertical") < 1) && Input.GetAxis("Horizontal") < 0) //Aiming UP RIGHT
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 112.5f);
            fireAngle = FireAngle2D.UUU_LEFT;
            //Debug.Log("U_RIGHT");
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
