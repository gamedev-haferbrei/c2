using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Globals.enemyToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
