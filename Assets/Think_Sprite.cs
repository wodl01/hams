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

    public GameObject Hamster;
    Move hamsterScript;

    public GameObject dish;

    private void Start()
    {
        hamsterScript = Hamster.GetComponent<Move>();
    }
    public void appear()
    {
        imote_Icon.SetActive(true);
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

        //if(hamsterScript.hunger < hamsterScript.hungerToFeed && )

        if (Input.GetKeyDown(KeyCode.D) && change == true)
        {
            change = false;
            animator.SetTrigger("Active");
            
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Active");
            imote_Icon.SetActive(false);
        }
        think_Icon.transform.position = hamster_pos.transform.position + new Vector3(left,up,0);
    }
}
