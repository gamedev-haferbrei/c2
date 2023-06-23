using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Globals.enemyClone = Instantiate(Globals.enemyToLoad, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
