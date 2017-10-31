using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class BossRoom : MonoBehaviour
{
    private GameObject mainCamera;


    private void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            mainCamera.GetComponent<Sidescoll>().bossRoom = true;
            StartCoroutine(MoveToBossRoom());
        }
    }


    private IEnumerator MoveToBossRoom()
    {
        while(true)
        {
            var newPosition = Vector3.Lerp(mainCamera.transform.position, transform.position, 0.5f * Time.deltaTime);
            mainCamera.transform.position = new Vector3(newPosition.x, mainCamera.transform.position.y, mainCamera.transform.position.z);

            if(Vector2.Distance(mainCamera.transform.position, transform.position) < 0.1f)
            {
                print("Lerp complete");
                break;
            }

            yield return false;
        }
        
        yield return true;
    }

}
