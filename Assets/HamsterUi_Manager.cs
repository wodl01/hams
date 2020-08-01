using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterUi_Manager : MonoBehaviour
{

    public int hamster_Id;
    public float hamster_Hunger;
    public float hamster_Thirsty;
    public SpriteRenderer hamster_Sprite;
    public Sprite hamsterThumbnail;


    public Text[] ui_text;
    
    public Image hamster_Shape;

    void Update()
    {

        ui_text[5].text = hamster_Hunger.ToString("N0") + "%";
        ui_text[6].text = hamster_Thirsty.ToString("N0") + "%";

        hamster_Shape.color = hamster_Sprite.color;
        hamster_Shape.sprite = hamsterThumbnail;
    }
}
