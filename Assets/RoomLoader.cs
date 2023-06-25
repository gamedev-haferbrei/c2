using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
    Room[] rooms;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Transform playerPos = player.GetComponent<Transform>();
        rooms = GetComponentsInChildren<Room>(includeInactive: true);
 
        if (Globals.roomBeforeBattle != null)
        {
            foreach (Room room in rooms)
            {
                if (room.name == Globals.roomBeforeBattle)
                {
                    LoadRoom(room);
                    playerPos.transform.position = Globals.playerPositionBeforeBattle;
                }
            }
            Globals.roomBeforeBattle = null;
             
        }
           
    }

    public void LoadRoom(Room room)
    {
        foreach (Room otherRoom in rooms)
        {
            otherRoom.Disable();
        }
        room.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
