using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Script : MonoBehaviour
{
    [SerializeField] bool isGet;
    [SerializeField] bool isChoice;

    [SerializeField] Text inputMoneyText;

    [SerializeField] int itemPrice;

    [SerializeField] dongScript manager;

    [SerializeField] GameObject warningOB;
    [SerializeField] WarningScript warningScript;

    [SerializeField] GameObject imoteOB;
    [SerializeField] WarningScript warningScript2;

    [SerializeField] GameObject beforeBuyingOB;
    [SerializeField] GameObject afterBuyingOB;

    public void BuyingItem()
    {
        if(manager.score >= itemPrice)
        {
            //success
            manager.score -= itemPrice;
            isGet = true;
            beforeBuyingOB.SetActive(false);
            afterBuyingOB.SetActive(true);
            warningScript2.InputWord = "구매완료!";
            Instantiate(imoteOB, new Vector3(0, 0, 0), Quaternion.identity);

        }
        else
        {
            warningScript.InputWord = "코인이 부족합니다.";
            Instantiate(warningOB, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    public void ChoiceItem()
    {
        if (isGet)
        {

        }
    }
    private void Update()
    {
        inputMoneyText.text = "" + "<color=#000000>" + itemPrice + "</color>" + "@";
    }
}
