using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var clone = Instantiate(Globals.enemyToLoad, Vector3.zero, Quaternion.identity);
        Globals.enemyClone = clone;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
