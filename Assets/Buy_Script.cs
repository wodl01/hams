using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Script : MonoBehaviour
{

    [SerializeField] Text inputMoneyText;


    [SerializeField] int itemPrice;
    [SerializeField] string itemName;
    [SerializeField] Sprite itemShape;

    [SerializeField] dongScript manager;
    [SerializeField] ButtenUiManagerScript buttenManager;
    [SerializeField] SelectScript select;

    [SerializeField] GameObject warningOB;
    [SerializeField] WarningScript warningScript;




    [SerializeField] GameObject beforeBuyingOB;
    [SerializeField] GameObject afterBuyingOB;
    [SerializeField] GameObject askOneMore;

    [SerializeField] askScript ask;

    private void Start()
    {
        inputMoneyText.text = "" + "<color=#000000>" + itemPrice + "</color>" + "@";
    }

    public void BuyingItem()
    {
        if(manager.score >= itemPrice)
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
    public void PassShape()
    {
        select.itemShape = itemShape;
    }
}
