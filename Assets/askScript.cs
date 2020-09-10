using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class askScript : MonoBehaviour
{
    [SerializeField] dongScript manager;
    [SerializeField] ButtenUiManagerScript buttenManager;

    [SerializeField] Text itemNameText;

    [SerializeField] WarningScript warningScript1;

    [SerializeField] GameObject imoteOB;


    public string itemName;
    public int itemPrice;
    public GameObject beforeButten;
    public GameObject afterButten;



    public void Yes()
    {
        manager.score -= itemPrice;
        beforeButten.SetActive(false);
        afterButten.SetActive(true);
        warningScript1.InputWord = "구매완료!";
        Instantiate(imoteOB, new Vector3(0, 0, 0), Quaternion.identity);
        buttenManager.shop_CanActive = true;
        gameObject.SetActive(false);
    }
    public void No()
    {
        
        buttenManager.shop_CanActive = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        itemNameText.text = itemName;
    }
}
