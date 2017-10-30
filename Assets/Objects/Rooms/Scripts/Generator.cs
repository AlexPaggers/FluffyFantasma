using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generator : MonoBehaviour
{
    // Room Types and lists of premade rooms. 
    public Dictionary<string, List<GameObject>> roomTypes;




    private List<GameObject> preInitActiveRooms = new List<GameObject>();
    private List<GameObject> activeRooms       = new List<GameObject>();
    private static RoomLists roomLists;
    private const string SAFE_ROOM = "Safe Room";
    private const string ROOM_01   = "Room 01";
    private const string ROOM_02   = "Room 02";
    private const string ROOM_03   = "Room 03";
    private const string ROOM_04   = "Room 04";
    private const string BOSS_ROOM = "Boss Room";



    private void Start()
    {
        roomLists = this.GetComponent<RoomLists>();
        roomTypes = new Dictionary<string, List<GameObject>>
        {
            { SAFE_ROOM, roomLists.safeRooms },
            { ROOM_01,   roomLists.rooms01   },
            { ROOM_02,   roomLists.rooms02   },
            { ROOM_03,   roomLists.rooms03   },
            { ROOM_04,   roomLists.rooms04   },
            { BOSS_ROOM, roomLists.bossRooms }
        };

        RegenerateLevel();
    }

    private void Update()
    {
        // For debugging
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.R))
        {
            RegenerateLevel();
        }
#endif
    }

    public void RegenerateLevel()
    {
        ResetLevel();
        AddRoomTypes();
        InstantiateRooms();
    }

    private void ResetLevel()
    {
        foreach (var roomPair in roomTypes)
        {
            var roomIdentifier = roomPair.Key;
            var roomList       = roomPair.Value;

            foreach (var room in roomList)
            {
                var roomScript = room.GetComponent<Room>();
                if (roomScript.Active)
                {
                    roomScript.Active = false;
                    print("Room from list " + roomIdentifier + " was set to active");
                }
            }
        }
        foreach (var room in activeRooms)
        {
            Destroy(room);
        }
        preInitActiveRooms.Clear();
        activeRooms.Clear();
    }

    private void AddRoomTypes()
    {
        for (int i = 0; i < roomTypes.Count; i++)
        {
            if (i == 0)
            {
                AddRoom(SAFE_ROOM);
                continue;
            }
            else if (i == (roomTypes.Count - 1))
            {
                AddRoom(BOSS_ROOM);
                continue;
            }
            else
            {
                AddRoom("Room 0" + i);
            }
        }
    }

    private void InstantiateRooms()
    {
        for (int i = 0; i < preInitActiveRooms.Count; i++)
        {
            var currentRoom  = preInitActiveRooms[i];

            print("current room: " + currentRoom);
            
            if(i == 0)
            {
                currentRoom.transform.position = new Vector2(0f, 0f);
               // currentRoom.SetActive(true);
                AddInitialisedRoom(currentRoom);
                continue;
            }
            var previousRoom = preInitActiveRooms[i - 1];

            var halfCurrentRoomSize  = (currentRoom.GetComponent<BoxCollider2D>().size.x / 2f);
            var halfPreviousRoomSize = (previousRoom.GetComponent<BoxCollider2D>().size.x / 2f);
            var offsetX = previousRoom.transform.position.x + halfPreviousRoomSize + halfCurrentRoomSize;

            currentRoom.transform.position = new Vector2(offsetX, 0f);
            //currentRoom.SetActive(false);
            AddInitialisedRoom(currentRoom);
        }
    }

    private void AddInitialisedRoom(GameObject room)
    {
        var initRooms = Instantiate(room);
        activeRooms.Add(initRooms);
    }


    private void AddRoom(string name)
    {
        if(!roomTypes.ContainsKey(name))
        {
            print("ERROR: Invalid room name passed in");
            return;
        }

        if (roomTypes[name].Count <= 0)
        {
            print("ERROR: The list for " + name + " is empty.");
            return;
        }
       
        var roomToAdd = SelectRandomRoom(name);
        roomToAdd.GetComponent<Room>().Active = true;
        preInitActiveRooms.Add(roomToAdd);
    }

    private GameObject SelectRandomRoom(string name)
    {
        var avaiableRooms = roomTypes[name].FindAll(room =>
        {
            return (!room.GetComponent<Room>().Active);
        });

        var probablityValue = Random.Range(0, avaiableRooms.Count);

        for (int i = 0; i < avaiableRooms.Count; i++)
        {
            var randomPick = Random.Range(0, avaiableRooms.Count);
            if (randomPick == probablityValue)
            {
                return avaiableRooms[i];
            }
            else
            {
                if(i == (avaiableRooms.Count - 1))
                {
                    return avaiableRooms[i];
                }
            }
        }
        return null;
    }
}
