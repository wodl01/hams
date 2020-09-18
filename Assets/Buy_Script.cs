using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Script : MonoBehaviour
{

    [SerializeField] Text inputMoneyText;
    [SerializeField] Text inputItemNameText;


    [SerializeField] int itemPrice;
    [SerializeField] string itemName;
    [SerializeField] Sprite[] itemShape;





    [SerializeField] dongScript manager;
    [SerializeField] ButtenUiManagerScript buttenManager;
    [SerializeField] SelectScript select;

    [SerializeField] GameObject warningOB;
    [SerializeField] WarningScript warningScript;







    [SerializeField] GameObject beforeBuyingOB;
    [SerializeField] GameObject afterBuyingOB;
    [SerializeField] GameObject askOneMore;

    [SerializeField] GameObject selectOB;

    [SerializeField] askScript ask;

    


    public bool cage1;
    public bool cage2;
    public bool cage3;

    private void Start()
    {
        inputMoneyText.text = "" + "<color=#000000>" + itemPrice + "</color>" + "@";
        //inputItemNameText.text = itemName;
    }


    public void BuyingItem()
    {
        if(buttenManager.shop_CanActive == true)
        {
            if (manager.score >= itemPrice)
            {
                //success
                buttenManager.shop_CanActive = false;
                ask.itemName = itemName;


                ask.itemPrice = itemPrice;
                askOneMore.SetActive(true);
                ask.beforeButten = beforeBuyingOB;
                ask.afterButten = afterBuyingOB;

            }
            else
            {
                warningScript.InputWord = "코인이 부족합니다.";
                Instantiate(warningOB, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
        
    }

        


    public void SelectSetActiveTrue()
    {
        if(buttenManager.shop_CanActive == true)
        {
            select.buy_Script = this;
            buttenManager.shop_CanActive = false;

            selectOB.SetActive(true);

            ChangeButtemImage();
        }
        
    }

    public void ChangeButtemImage()
    {

        if (cage1 == true)
        {
            select.cage1 = true;
            for (int i = 0; i < itemShape.Length; i++)
            {
                select.cage1OB[i].sprite = itemShape[i];
            }
        }
        else
        {
            select.cage1 = false;
        }

        if (cage2 == true)
        {
            select.cage2 = true;
            for (int i = 0; i < itemShape.Length; i++)
            {
                select.cage2OB[i].sprite = itemShape[i];
            }
        }
        else
        {
            select.cage2 = false;
        }

        if (cage3 == true)
        {
            select.cage3 = true;
            for (int i = 0; i < itemShape.Length; i++)
            {
                select.cage3OB[i].sprite = itemShape[i];
            }
        }
        else
        {
            select.cage3 = false;
        }
    }
    

    
}
