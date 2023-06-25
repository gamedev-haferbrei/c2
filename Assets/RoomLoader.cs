using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoader : MonoBehaviour
{
    Room[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = GetComponentsInChildren<Room>(includeInactive: true);
        Debug.Log("Roomloader 1" + Globals.roomBeforeBattle); ///////////////////////......
        Debug.Log("Roomloader 1" + Globals.playerPositionBeforeBattle); 
        if (Globals.roomBeforeBattle != null)
        {
            LoadRoom(Globals.roomBeforeBattle);
            Globals.roomBeforeBattle = null;
            Debug.Log("Roomloader 2" + Globals.roomBeforeBattle);
            
        } ///////////////////////////////////////////////......
            
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
