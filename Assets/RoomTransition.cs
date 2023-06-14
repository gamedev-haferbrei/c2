using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] Transform target;

    RoomLoader roomLoader;
    Room room;

    // Start is called before the first frame update
    void Start()
    {
        roomLoader = GetComponentInParent<RoomLoader>();
        room = GetComponentInParent<Room>(includeInactive: true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerWarp>().WarpTo(target.position);
            roomLoader.LoadRoom(room);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
