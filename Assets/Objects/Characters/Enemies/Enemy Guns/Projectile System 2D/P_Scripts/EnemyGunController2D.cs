using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ONLY FOR ENEMIES NOT FOR PLAYER, made a copy-pasta in case anyone was editing the original

public class EnemyGunController2D : MonoBehaviour
{

    public int rotationOffset = 0;
	public float accuracy = 10f;
	public static float aim = 0f;

	void Start ()
	{
		//transform.Rotate (Quaternion.Euler (0f, 0f, rotationOffset));
	}
    // Update is called once per frame
    void Update()
    {
		
		aim = Random.Range(-accuracy, accuracy);
        
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
