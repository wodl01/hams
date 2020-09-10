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

}
