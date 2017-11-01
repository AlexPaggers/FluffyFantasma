using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject prevRoom;
    public GameObject platformPrefab;
    public float randRoomX = 0f;
    public List<GameObject> roomOnePlatforms = new List<GameObject>();
    public List<GameObject> roomTwoPlatforms = new List<GameObject>();

    public bool bossMode = false;


    private Sidescoll sideScroll;
    private float roomOneMin = 0f;
    private float roomOneMax = 0f;
    private float roomTwoMin = 0f;
    private float roomTwoMax = 0f;


    public float timer = 0f;
    public float MAX_TIME = 5f;




    private void Start()
    {
        sideScroll = mainCam.GetComponent<Sidescoll>();
        SetPreviousRoom();
        roomOneMin = -5.5f;
        roomOneMax = 7f;
        roomTwoMin = 10.98f;
        roomTwoMax = 23.6f;
    }


    private void Update()
    {
        if (TrapDoor.TrapDoorHit)
        {
            SetPreviousRoom();

            StopAllCoroutines();
            StartCoroutine(LoadPlatforms());
        }
    }

    private void Regenerate()
    {
        if (!bossMode)
        {
            AddPlatforms();
        }
        else
        {
            // Boss Mode
        }
    }

    private void ClearRooms()
    {
        if (prevRoom == sideScroll.roomOne)
        {
            foreach (var platform in roomOnePlatforms)
            {
                Destroy(platform);
            }
            roomOnePlatforms.Clear();
        }
        else
        {
            foreach (var platform in roomTwoPlatforms)
            {
                Destroy(platform);
            }
            roomTwoPlatforms.Clear();

        }
    }


    private void SetPreviousRoom()
    {
        if (sideScroll.currentRoom == sideScroll.roomOne)
        {
            prevRoom = sideScroll.roomOne;
        }
        else
        {
            prevRoom = sideScroll.roomTwo;
        }
    }


    private void RandomPositionX()
    {
        if(prevRoom == sideScroll.roomOne)
        {
            randRoomX = Random.Range(roomOneMin, roomOneMax);
        }
        else
        {
            randRoomX = Random.Range(roomTwoMin, roomTwoMax);
        }
    }


    private void AddPlatforms()
    {
        var newPosition = Vector2.zero;

        for (int i = 0; i < 3; i++)
        {
            print("Adding platforms " + i);
            RandomPositionX();

            if (i == 0)
            {
                newPosition = new Vector2(randRoomX, 2.25f);
            }
            else if (i == 1)
            {
                newPosition = new Vector2(randRoomX, 0f);
            }
            else if (i == 2)
            {
                newPosition = new Vector2(randRoomX, -2.25f);
            }

            var newPlatform = Instantiate(platformPrefab, newPosition, Quaternion.identity);
            if (prevRoom == sideScroll.roomOne)
            {
                roomOnePlatforms.Add(newPlatform);
            }
            else
            {
                roomTwoPlatforms.Add(newPlatform);
            }
        }
    }



    private IEnumerator LoadPlatforms()
    {
        while(true)
        {
            if (timer >= (MAX_TIME / 2f) && timer <= MAX_TIME)
            {
                ClearRooms();
            }

            if (timer <= MAX_TIME)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Regenerate();
                timer = 0f;
                break;
            }
            yield return false;
        }
        yield return true;
    }
}
