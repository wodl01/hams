using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishChoiceScript : MonoBehaviour
{
    [SerializeField] bool dish_Shop;
    [SerializeField] bool waterBowl_Shop;
    [SerializeField] bool sand_Shop;
    [SerializeField] bool rurrer_Shop;
    [SerializeField] bool bedding_Shop;
    [SerializeField] bool wallPaper_Shop;

    [SerializeField] SpriteRenderer dishShape;
    [SerializeField] SpriteRenderer feedShape;
    [SerializeField] SpriteRenderer feedShape2;
    ////////////////////////////////////////////////
    [SerializeField] Sprite[] dishItem;
    [SerializeField] Sprite[] feedItem;
    [SerializeField] Sprite[] feedItem2;


    [SerializeField] Image[] butten;
    [SerializeField] Sprite celectedButtenSprite;
    [SerializeField] Sprite notCelectedButtenSprite;
    public void _1Item_1_Cellect()
    {
        butten[0].sprite = celectedButtenSprite;
        
        if(dish_Shop == true)
        {
            dishShape.sprite = dishItem[0];
            feedShape.sprite = feedItem[0];
            feedShape2.sprite = feedItem2[0];
        }
        
    }
    public void _1Item_2_Cellect()
    {
        butten[1].sprite = celectedButtenSprite;
        
        if (dish_Shop == true)
        {
            dishShape.sprite = dishItem[1];
            feedShape.sprite = feedItem[1];
            feedShape2.sprite = feedItem2[1];
        }
    }
    public void _1Item_3_Cellect()
    {
        butten[2].sprite = celectedButtenSprite;
        
        if (dish_Shop == true)
        {
            dishShape.sprite = dishItem[2];
            feedShape.sprite = feedItem[2];
            feedShape2.sprite = feedItem2[2];
        }
    }
    public void _1Item_4_Cellect()
    {
        butten[3].sprite = celectedButtenSprite;
        
        if (dish_Shop == true)
        {
            dishShape.sprite = dishItem[3];
            feedShape.sprite = feedItem[3];
            feedShape2.sprite = feedItem2[3];
        }
    }
    public void _1Item_5_Cellect()
    {
        butten[4].sprite = celectedButtenSprite;
        
        if (dish_Shop == true)
        {
            dishShape.sprite = dishItem[4];
            feedShape.sprite = feedItem[4];
            feedShape2.sprite = feedItem2[4];
        }
    }
    public void _1Item_6_Cellect()
    {
        butten[5].sprite = celectedButtenSprite;
        
        if (dish_Shop == true)
        {
            dishShape.sprite = dishItem[5];
            feedShape.sprite = feedItem[5];
            feedShape2.sprite = feedItem2[5];
        }
    }
    public void _1Item_7_Cellect()
    {
        butten[6].sprite = celectedButtenSprite;
        
        if (dish_Shop == true)
        {
            dishShape.sprite = dishItem[6];
            feedShape.sprite = feedItem[6];
            feedShape2.sprite = feedItem2[6];
        }
    }
    public void _1Item_8_Cellect()
    {
        butten[7].sprite = celectedButtenSprite;
        
        if (dish_Shop == true)
        {
            dishShape.sprite = dishItem[7];
            feedShape.sprite = feedItem[7];
            feedShape2.sprite = feedItem2[7];
        }
    }


    ///////////////////////////////////////////////////////////
    
    /*
    public void _2Item_1_Canceled()
    {
        butten[0].sprite = notCelectedButtenSprite;
    }
    public void _2Item_2_Canceled()
    {
        butten[1].sprite = notCelectedButtenSprite;
    }
    public void _2Item_3_Canceled()
    {
        butten[2].sprite = notCelectedButtenSprite;
    }
    public void _2Item_4_Canceled()
    {
        butten[3].sprite = notCelectedButtenSprite;
    }
    public void _2Item_5_Canceled()
    {
        butten[4].sprite = notCelectedButtenSprite;
    }
    public void _2Item_6_Canceled()
    {
        butten[5].sprite = notCelectedButtenSprite;
    }*/
}
