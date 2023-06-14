using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void WarpTo(Vector2 position)
    {
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
