using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] Transform target;

    RoomLoader roomLoader;

    // Start is called before the first frame update
    void Start()
    {
        roomLoader = GameObject.FindWithTag("Room Loader").GetComponent<RoomLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerWarp>().WarpTo(target.position);
            roomLoader.LoadRoom(collision.gameObject.GetComponentInParent<Room>(includeInactive: true));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
