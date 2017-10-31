using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Dictionary<string, GameObject> allSpawnedObject = new Dictionary<string, GameObject>();
    public GameObject objectToSpawn = null;
    public bool initOnStart = false;


    private void Start()
    {
        if(objectToSpawn == null)
        {
            print("ERROR: object spawner without object.");
            return;
        }
        if(!initOnStart) return;
        SpawnObject();
    }


    public void SpawnObject()
    {
        var tempObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        allSpawnedObject.Add(objectToSpawn.name, objectToSpawn);
    }
}
