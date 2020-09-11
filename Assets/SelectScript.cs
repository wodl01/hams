using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScript : MonoBehaviour
{
    public SpriteRenderer[] cage1OB;

    public SpriteRenderer[] cage2OB;

    public SpriteRenderer[] cage3OB;

    public Image cage1Button;
    public Image cage2Button;
    public Image cage3Button;

    public bool cage1;
    public bool cage2;
    public bool cage3;



    [SerializeField] Sprite selectedButtenImage;
    [SerializeField] Sprite notSelectedButtenImage;

    public Buy_Script buy_Script;

    [SerializeField] Buy_Script[] Buy_TurnOff;
    public void SelectOpen()
    {
        gameObject.SetActive(true);
    }
    public void XButten()
    {
        gameObject.SetActive(false);
    }



    public void Cage1OnClick()
    {
        if (!buy_Script.cage1)
        {
            
            foreach (Buy_Script delete in Buy_TurnOff)
            {
                delete.cage1 = false;
            }
            buy_Script.cage1 = true;
            buy_Script.ChangeButtemImage();
        }
        /*else if (buy_Script.cage1)
        {
            buy_Script.cage1 = false;
            buy_Script.ChangeButtemImage();
        }*/
         

    }
    public void Cage2OnClick()
    {
        if (!buy_Script.cage2)
        {
            foreach (Buy_Script delete in Buy_TurnOff)
            {
                delete.cage2 = false;
            }
            buy_Script.cage2 = true;
            buy_Script.ChangeButtemImage();
        }
        /*else if (buy_Script.cage2)
        {
            buy_Script.cage2 = false;
            buy_Script.ChangeButtemImage();
        }*/

    }
    public void Cage3OnClick()
    {
        if (!buy_Script.cage3)
        {
            foreach (Buy_Script delete in Buy_TurnOff)
            {
                delete.cage3 = false;
            }
            buy_Script.cage3 = true;
            buy_Script.ChangeButtemImage();
        }
        /*else if (buy_Script.cage3)
        {
            buy_Script.cage3 = false;
            buy_Script.ChangeButtemImage();
        }*/

    }
    private void Update()
    {
        if (cage1)
        {
            cage1Button.sprite = selectedButtenImage;
        }
        else
        {
            cage1Button.sprite = notSelectedButtenImage;
        }
        if (cage2)
        {
            cage2Button.sprite = selectedButtenImage;
        }
        else
        {
            cage2Button.sprite = notSelectedButtenImage;
        }
        if (cage3)
        {
            cage3Button.sprite = selectedButtenImage;
        }
        else
        {
            cage3Button.sprite = notSelectedButtenImage;
        }
    }
}
