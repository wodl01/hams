using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrer : MonoBehaviour
{
    GameObject Ham;
    public Move movScript;

    public bool Up;
    public bool Dawn;
    public bool Left;
    public bool Right;

    public BoxCollider2D box;

    

    int DawnRandomNum;
    int UpRandomNum;
    int RightRandomNum;
    int LeftRandomNum;

    //1)//Idle
    //2)//Up
    //3)//Dawn
    //4)//Right
    //5)//Left
    //6)//Up.Left
    //7)//Up.Right
    //8)//Dawn.Left
    //9)//Dawn.Right
    private void Start()
    {

       // Ham = GameObject.FindGameObjectWithTag("HamSter");
       // movScript = Ham.GetComponent<Move>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        movScript = other.GetComponent<Move>();
        if (other.tag == "HamSter")
        {
            Debug.Log("닿음1");

            if (Up == true) movScript.barrierUp = true;
            if (Dawn == true) movScript.barrierDawn = true;
            if (Left == true) movScript.barrierLeft = true;
            if (Right == true) movScript.barrierRight = true;
            movScript.StartCoroutine("StopMove");


        }
    }
    
        
    
    
}
