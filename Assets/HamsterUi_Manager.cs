using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterUi_Manager : MonoBehaviour
{

    public int hamster_Id;
    public float hamster1_Hunger;
    public SpriteRenderer hamster_Sprite;


    public Text hunger_Text;
    public Image hamster_Shape;
    void Update()
    {

        hunger_Text.text = hamster1_Hunger.ToString("N0") + "%";
        hamster_Shape.color = hamster_Sprite.color;
    }
}
