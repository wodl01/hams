using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Think_Sprite : MonoBehaviour
{
    public float left;
    public float up;

    public bool change;

    public GameObject hamster_pos;
    public GameObject think_Icon;
    public GameObject imote_Icon;

    public bool HamsterIsMid;
    public bool HamsterIsBottom;//-0.37 0.25

    public Animator animator;

    public GameObject hamster;
    [SerializeField]Move hamsterScript;

    [SerializeField] GameObject dish;
    [SerializeField]DishScript dishScript;

    public GameObject think_Image_OB;
    [SerializeField] SpriteRenderer think_sprite;
    [SerializeField] Sprite think_Image1;
    [SerializeField] Sprite think_Image2;
    [SerializeField] Sprite think_Image3;
    [SerializeField] Sprite think_Image4;
    [SerializeField] Sprite think_Image5;

    private void Start()
    {
        hamsterScript = hamster.GetComponent<Move>();

        dish = GameObject.Find("dish");
        dishScript = dish.GetComponent<DishScript>();

        think_sprite = think_Image_OB.GetComponent<SpriteRenderer>();
    }
    public void appear()
    {
        imote_Icon.SetActive(true);
    }
    private void Update()
    {

        //if,else if,else if...반복알고리즘
        if(hamsterScript.iamHungry == true)
        {
            think_sprite.sprite = think_Image1;
        }
        else if (hamsterScript.iamHungry == true)//이거바꿔
        {
            think_sprite.sprite = think_Image2;
        }

        if(HamsterIsBottom == true)
        {
            left = -0.37f;
            up = 0.25f;
        }
        if(HamsterIsBottom == false)
        {
            left = -0.19f;
            up = 0.46f;
        }

        if(hamsterScript.hunger < hamsterScript.hungerToFeed && dishScript.isFull == false)
        {
            animator.SetBool("Active", true);
        }
        else
        {
            animator.SetBool("Active", false);
            imote_Icon.SetActive(false);
        }

        think_Icon.transform.position = hamster_pos.transform.position + new Vector3(left,up,0);
    }
}
