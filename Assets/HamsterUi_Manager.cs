using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterUi_Manager : MonoBehaviour
{
    public int hamster_Lv;
    public float hamster_Intimacy;
    public string hamster_Name;
    public int hamster_Id;
    public float hamster_Hunger;
    public float hamster_Thirsty;
    public int hamster_StressValue;
    public SpriteRenderer hamster_Sprite;
    public Sprite hamsterThumbnail;


    public Text[] ui_text;
    
    [SerializeField] Image hamster_Shape;
    [SerializeField] Image slider;
    [SerializeField] Image hamster_condition;
    [SerializeField] Sprite[] sprite;
    void Update()
    {
        ui_text[2].text = "Lv." + hamster_Lv.ToString();
        ui_text[3].text = hamster_Name;

        ui_text[7].text = hamster_Intimacy.ToString("N0") + "%";
        slider.fillAmount = hamster_Intimacy * 1/100;

        ui_text[5].text = hamster_Hunger.ToString("N0") + "%";
        ui_text[6].text = hamster_Thirsty.ToString("N0") + "%";

        if(hamster_StressValue == 0)
        {
            hamster_condition.sprite = sprite[0];
        }
        else if(hamster_StressValue == 1)
        {
            hamster_condition.sprite = sprite[1];
        }
        else if (hamster_StressValue == 2)
        {
            hamster_condition.sprite = sprite[2];
        }
        else if (hamster_StressValue == 3)
        {
            hamster_condition.sprite = sprite[3];
        }

        hamster_Shape.color = hamster_Sprite.color;
        hamster_Shape.sprite = hamsterThumbnail;
    }
}
