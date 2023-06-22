using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    [SerializeField] Battle battleGO;
    [SerializeField] TextMeshProUGUI textGO;

    Image image;
    TextMeshProUGUI text;   

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        text = textGO.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = (float)(battleGO.playerHP) / (float)(10);
        text.text = battleGO.playerHP + "/10"; 
    }
}
