using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TrapDoor : MonoBehaviour
{
    private static bool trapDoorHit;
    public static bool TrapDoorHit
    {
        get
        {
            return trapDoorHit;
        }
        
        internal set
        {
            trapDoorHit = value;
        }
    }

    private void Start()
    {
        TrapDoorHit = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {

            TrapDoorHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TrapDoorHit = false;
        }
    }
	
}
