using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Script : MonoBehaviour
{
    [SerializeField] Text inputMoneyText;

    [SerializeField] int itemPrice;

    [SerializeField] dongScript manager;

    [SerializeField] GameObject warningOB;
    [SerializeField] WarningScript warningScript;
    public void BuyingItem()
    {
        if(manager.score >= itemPrice)
        {
            //success
            manager.score -= itemPrice;
        }
        else
        {
            warningScript.InputWord = "코인이 부족합니다.";
            Instantiate(warningOB, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    private void Update()
    {
        inputMoneyText.text = "" + "<color=#000000>" + itemPrice + "</color>" + "@";
    }
}
