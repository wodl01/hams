using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishScript : MonoBehaviour
{
    public GameObject feed;
    public GameObject Sign;

    public bool isFull;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFull == false)
        {
            feed.SetActive(false);
            Sign.SetActive(true);
            //isFull = true;// 테스트용
        }
        if (isFull == true)
        {
            feed.SetActive(true);
            Sign.SetActive(false);

        }
    }
}
