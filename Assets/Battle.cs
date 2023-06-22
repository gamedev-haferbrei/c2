using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Battle : MonoBehaviour
{
    [SerializeField] GameObject textGO;

    TextMeshProUGUI text;

    public bool isDefending;
    public bool isCharging;
    public int playerHP;
    public int enemyHP;

    public void Attack()
    {
        int i = Random.Range(1, 3);
        enemyHP -= i;
        text.text = "Enemy takes " + i + " damage";
        AITurn();
    }

    public void Defend()
    {
        isDefending = true;
        text.text = "You are defending.";
        AITurn();
    }

    public void Heal()
    {
        playerHP += 5;
        text.text = "You heal 5 HP.";
        AITurn();
    }
    
    public void Run()
    {
        SceneManager.LoadScene("Main"); // TODO return to previous pos not to start

    }

    public void AITurn()
    {
        if (isDefending)
        {
            text.text = "You blocked incoming damage!";
            isDefending = false;
            return;
        }
        if (isCharging)
        {
            playerHP -= 7;
            text.text = "That hurts! Should have blocked that.";
            isCharging = false;
            return;
        }

        int r = Random.Range(1, 101);
        
        if (r <= 64)
        {
            int i = Random.Range(2, 4);
            text.text = "AI attacks! You take " + i + " damage.";
            playerHP -= i;
            //CheckHP();                                                   // TODO
        }
        else if (r > 64)
        {
            isCharging = true;
            text.text = "AI is charging deadly attack, watch out!";
        }
        isDefending = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        isDefending = false;
        playerHP = 10;
        enemyHP = 10;
        text = textGO.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
