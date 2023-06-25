using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchBattle : MonoBehaviour
{
    InputActions controls;

    GameObject playerInRange = null;

    [SerializeField] GameObject enemyToLoad;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new InputActions();
    }

    private void OnEnable()
    {
        controls.Player.EnterBattle.performed += _ => TryEnterBattle();

        controls.Enable();
    }

    private void OnDisable() => controls.Disable();

    // Update is called once per frame
    void Update()
    {
        
    }

    void TryEnterBattle()
    {
        if (playerInRange != null)
        {
            if (Globals.roomBeforeBattle == null) { Globals.roomBeforeBattle = GetComponentInParent<Slime>().GetComponentInParent<Room>(); } ///////////////////
            Debug.Log("LaunchBattle " + Globals.roomBeforeBattle.name); ///////////////////////////////////
            Globals.playerPositionBeforeBattle = playerInRange.transform.position;
            Globals.enemyToLoad = enemyToLoad;
            SceneManager.LoadScene("Battle");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerInRange = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerInRange = null;
    }
}
