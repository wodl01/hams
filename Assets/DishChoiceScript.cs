using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishChoiceScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer dishShape;
    [SerializeField] SpriteRenderer feedShape;
    [SerializeField] SpriteRenderer feedShape2;

    [SerializeField] Sprite[] dishItem;
    [SerializeField] Sprite[] feedItem;
    [SerializeField] Sprite[] feedItem2;

    [SerializeField] Image[] butten;
    [SerializeField] Sprite celectedButtenSprite;
    [SerializeField] Sprite notCelectedButtenSprite;
    [SerializeField] bool clicked;
    public void Item_1_Cellect()
    {
        butten[0].sprite = celectedButtenSprite;
    }
    public void Item_2_Cellect()
    {
        butten[1].sprite = celectedButtenSprite;
    }
    public void Item_3_Cellect()
    {
        butten[2].sprite = celectedButtenSprite;
    }
    public void Item_4_Cellect()
    {
        butten[3].sprite = celectedButtenSprite;
    }
    public void Item_5_Cellect()
    {
        butten[4].sprite = celectedButtenSprite;
    }


    ///////////////////////////////////////////////////////////
    public void Item_1_Canceled()
    {
        butten[0].sprite = notCelectedButtenSprite;
    }
    public void Item_2_Canceled()
    {
        butten[1].sprite = notCelectedButtenSprite;
    }
    public void Item_3_Canceled()
    {
        butten[2].sprite = notCelectedButtenSprite;
    }
    public void Item_4_Canceled()
    {
        butten[3].sprite = notCelectedButtenSprite;
    }
    public void Item_5_Canceled()
    {
        butten[4].sprite = notCelectedButtenSprite;
    }
}
