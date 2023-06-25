using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Battle : MonoBehaviour
{
    [SerializeField] GameObject textGO;
    [SerializeField] Button[] buttonsGO;

    TextMeshProUGUI text;
    Animator animator;

    public bool isDefending;
    public bool isCharging;
    public int playerHP;
    public int enemyHP;
    public float attackTime, hitTime, specialTime;

    public void Attack()
    {
        BlockButtons(buttonsGO);
        int i = Random.Range(1, 3);
        animator.SetTrigger("hit");
        enemyHP -= i;
        text.text = "Enemy takes " + i + " damage";
        
        StartCoroutine(Animation(text));
        CheckHP();
        Invoke("AITurn", 3);
    }

    public void Defend()
    {
        BlockButtons(buttonsGO);
        isDefending = true;
        text.text = "You are defending.";
        StartCoroutine(Animation(text));
        Invoke("AITurn", 3);
    }

    public void Heal()
    {
        BlockButtons(buttonsGO);
        playerHP = playerHP < 5 ? playerHP + 5 : 10;
        text.text = "You heal 5 HP.";
        StartCoroutine(Animation(text));
        Invoke("AITurn", 3);
    }
    
    public void Run()
    {
        Debug.Log("Run " + Globals.roomBeforeBattle); /////////////////////////////////////////////
        SceneManager.LoadScene("Main"); // TODO return to previous pos not to start
    }

    public void AITurn()
    {        
        if (isDefending)
        {
            text.text = "You blocked incoming damage!";
            if (isCharging) animator.SetTrigger("special");
            else animator.SetTrigger("attack");
            StartCoroutine(Animation(text));
            isDefending = false;
            isCharging = false;
            CheckHP();
            BlockButtons(buttonsGO);
            return;
        }
        if (isCharging)
        {
            playerHP = playerHP > 7 ? playerHP - 7 : 0;
            animator.SetTrigger("special");
            text.text = "That hurts! Should have blocked that.";
            StartCoroutine(Animation(text));
            isCharging = false;
            CheckHP();
            BlockButtons(buttonsGO);
            return;
        }

        int r = Random.Range(1, 101);
        
        if (r <= 64)
        {
            int i = Random.Range(2, 4);
            animator.SetTrigger("attack");
            text.text = "AI attacks! You take " + i + " damage.";
            
            StartCoroutine(Animation(text));
            playerHP = playerHP > i ? playerHP - i : 0;
            
        }
        else if (r > 64)
        {
            isCharging = true;
            text.text = "AI is charging deadly attack, watch out!";
            StartCoroutine(Animation(text));
        }
        CheckHP();
        isDefending = false;
        BlockButtons(buttonsGO);
    }

    public void CheckHP()
    {
        if (enemyHP <= 0)
        {
            text.text = "You won!";
            StartCoroutine(Animation(text));
            Run();
        }
        if (playerHP <= 0)
        {
            text.text = "You lost!";
            StartCoroutine(Animation(text));
            Run();
        }
    }

    public void BlockButtons(Button[] buttons)
    {
        foreach (Button button in buttons)
        {
            Debug.Log(button);
            button.interactable = !button.interactable;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //buttonsGO = GetComponentsInChildren<Button>();
        isDefending = false;
        playerHP = 10;
        enemyHP = 10;
        text = textGO.GetComponent<TextMeshProUGUI>();
        text.text = "";
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        animator = Globals.enemyClone.GetComponent<Animator>();
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Attack":
                    attackTime = clip.length;
                    break;
                case "Hit":
                    hitTime = clip.length;
                    break;
                case "Special":
                    specialTime = clip.length;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Animation(TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        
        while (text.color.a > 0.0f)

        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2f));
            yield return null;           
            //yield return new WaitForSecondsRealtime(anim);
        }
    }
}
