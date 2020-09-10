using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer objectShapeCage1;
    [SerializeField] SpriteRenderer objectShapeCage2;
    [SerializeField] SpriteRenderer objectShapeCage3;


    public Sprite itemShape;

    public void SelectOpen()
    {
        gameObject.SetActive(true);
    }
    public void XButten()
    {
        gameObject.SetActive(false);
    }


    public void num1()
    {
        objectShapeCage1.sprite = itemShape;
    }
    public void num2()
    {
        objectShapeCage2.sprite = itemShape;
    }
    public void num3()
    {
        objectShapeCage3.sprite = itemShape;
    }
}
