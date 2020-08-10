using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_Script : MonoBehaviour
{

    [SerializeField] Text inputMoneyText;
    [SerializeField] Text input_Ask_ItemName_Text;

    [SerializeField] int itemPrice;
    [SerializeField] string itemName;

    [SerializeField] dongScript manager;
    [SerializeField] ButtenUiManagerScript buttenManager;

    [SerializeField] GameObject warningOB;
    [SerializeField] WarningScript warningScript;

    [SerializeField] GameObject imoteOB;
    [SerializeField] WarningScript warningScript2;

    [SerializeField] GameObject beforeBuyingOB;
    [SerializeField] GameObject afterBuyingOB;
    [SerializeField] GameObject askOneMore;

    public void BuyingItem()
    {
        if(manager.score >= itemPrice)
        {
            //success
            buttenManager.shop_CanActive = false;
            input_Ask_ItemName_Text.text = '"' + itemName + '"';
            askOneMore.SetActive(true);

        }
        else
        {
            warningScript.InputWord = "코인이 부족합니다.";
            Instantiate(warningOB, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    public void Yes()
    {
        manager.score -= itemPrice;
        beforeBuyingOB.SetActive(false);
        afterBuyingOB.SetActive(true);
        askOneMore.SetActive(false);
        warningScript2.InputWord = "구매완료!";
        Instantiate(imoteOB, new Vector3(0, 0, 0), Quaternion.identity);
        buttenManager.shop_CanActive = true;
    }
    public void No()
    {
        askOneMore.SetActive(false);
        buttenManager.shop_CanActive = true;
    }

    private void Update()
    {
        inputMoneyText.text = "" + "<color=#000000>" + itemPrice + "</color>" + "@";
    }
}
