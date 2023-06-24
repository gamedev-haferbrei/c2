using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Battle : MonoBehaviour
{
    [SerializeField] GameObject textGO;


    GameObject enemyClone;
    TextMeshProUGUI text;
    Animator animator;

    public bool isDefending;
    public bool isCharging;
    public int playerHP;
    public int enemyHP;

    public void Attack()
    {
        int i = Random.Range(1, 3);
        enemyHP -= i;
        text.text = "Enemy takes " + i + " damage";
        StartCoroutine(FadeText(text));
        animator.SetTrigger("hit");
        CheckHP();
        AITurn();
    }

    public void Defend()
    {
        isDefending = true;
        text.text = "You are defending.";
        StartCoroutine(FadeText(text));
        AITurn();
    }

    public void Heal()
    {
        playerHP = playerHP < 5 ? playerHP + 5 : 10;
        text.text = "You heal 5 HP.";
        StartCoroutine(FadeText(text));
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
            StartCoroutine(FadeText(text));
            isDefending = false;
            isCharging = false;
            CheckHP();
            return;
        }
        if (isCharging)
        {
            playerHP = playerHP > 7 ? playerHP - 7 : 0;
            text.text = "That hurts! Should have blocked that.";
            StartCoroutine(FadeText(text));
            isCharging = false;
            CheckHP();
            return;
        }

        int r = Random.Range(1, 101);
        
        if (r <= 64)
        {
            int i = Random.Range(2, 4);
            text.text = "AI attacks! You take " + i + " damage.";
            StartCoroutine(FadeText(text));
            playerHP = playerHP > i ? playerHP - i : 0;
            animator.SetTrigger("attack");
        }
        else if (r > 64)
        {
            isCharging = true;
            text.text = "AI is charging deadly attack, watch out!";
            StartCoroutine(FadeText(text));
            animator.SetTrigger("special");
        }
        CheckHP();
        isDefending = false;
    }

    public void CheckHP()
    {
        if (enemyHP == 0)
        {
            text.text = "You won!";
            StartCoroutine(FadeText(text));
            Run();
        }
        if (playerHP == 0)
        {
            text.text = "You lost!";
            StartCoroutine(FadeText(text));
            Run();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isDefending = false;
        playerHP = 10;
        enemyHP = 10;
        text = textGO.GetComponent<TextMeshProUGUI>();
        animator = Globals.enemyClone.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeText(TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / 2f));
            yield return null;
        }
    }
}
