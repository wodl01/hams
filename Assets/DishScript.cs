using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishScript : MonoBehaviour
{
    public GameObject feed;
    public GameObject sign;
    public GameObject coinEffect;

    public bool isFull;
    public int feedValue;
    public TextMesh text;
    public void MinusCoin()
    {
        text.text = "-" + "<color=#000000>" + feedValue + "</color>" + "@";
        coinEffect.SetActive(true);
    }
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
