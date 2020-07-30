using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Think_Sprite : MonoBehaviour
{
    public float left;
    public float up;
    [SerializeField] float changingTime;

    public bool change;

    public GameObject hamster_pos;
    public GameObject think_Icon;
    public GameObject imote_Icon;
    public GameObject heart;
    public GameObject heart_spawn;

    public bool HamsterIsMid;
    public bool HamsterIsBottom;//-0.37 0.25
    //-3.3 8.3

    //-6.1 7.58

    [SerializeField] bool voidUpdateOnce;

    public Animator animator;

    public GameObject hamster;
    [SerializeField]Move hamsterScript;

    [SerializeField] GameObject dish;
    [SerializeField] DishScript dishScript;
    [SerializeField] GameObject waterbowl;
    [SerializeField] WaterBowlScript waterBowlScript;

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
        waterbowl = GameObject.Find("waterbowl");
        waterBowlScript = waterbowl.GetComponent<WaterBowlScript>();
        

        think_sprite = think_Image_OB.GetComponent<SpriteRenderer>();

        StartCoroutine("ImageChange");
    }

    IEnumerator ImageChange()
    {

        if (hamsterScript.iamThirsty == true)
        {
            think_sprite.sprite = think_Image1;
            yield return new WaitForSeconds(changingTime);

        }

        if (hamsterScript.iamHungry == true)
        {

            think_sprite.sprite = think_Image2;
            yield return new WaitForSeconds(changingTime);

        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ImageChange());
    }

    public void appear()
    {
        imote_Icon.SetActive(true);
    }
    public void disappear()
    {
        imote_Icon.SetActive(false);
    }
    public void ResetVoidUpdateOnce()
    {
        voidUpdateOnce = true;
    }
    private void Update()
    {

        

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

        if(hamsterScript.iamHungry == true && dishScript.isFull == false)
        {
            animator.SetBool("Active", true);

        }
        else if(hamsterScript.iamThirsty == true && waterBowlScript.waterGauge == 0)
        {
            animator.SetBool("Active", true);

        }
        else
        {
            Debug.Log("333333");
            if (voidUpdateOnce)
            {
                Debug.Log("3333334");
                voidUpdateOnce = false;
                animator.SetBool("Active", false);
                Instantiate(heart, heart_spawn.transform.position, Quaternion.identity);
            }
            
        }

        think_Icon.transform.position = hamster_pos.transform.position + new Vector3(left,up,0);
    }
}
