using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room : MonoBehaviour
{
    public bool activeInLevel = false;
    public bool Active
    {
        get
        {
            return activeInLevel;
        }
        set
        {
            activeInLevel = value;
        }
    }
}
