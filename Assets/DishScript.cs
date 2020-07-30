using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishScript : MonoBehaviour
{
    public GameObject feed;
    public GameObject sign;


    public bool isFull;
    

    // Update is called once per frame
    void Update()
    {
        if (isFull == false)
        {
            feed.SetActive(false);
            sign.SetActive(true);
            //isFull = true;// 테스트용
        }
        if (isFull == true)
        {
            feed.SetActive(true);
            sign.SetActive(false);

        }
    }
}
