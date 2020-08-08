using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtenUiManagerScript : MonoBehaviour
{
    [SerializeField] Ui_ChangeManager UiChange_Manager;
    [SerializeField] GameObject myHamsterUi;

    [SerializeField] GameObject[] shop_Ui;
    [SerializeField] Canvas[] shopCanvas;

    [SerializeField] dongScript manager;

    public bool canActive;

    public void Xbutten()
    {
        manager.canActive_My = true;
        UiChange_Manager.stage = 1;
        myHamsterUi.SetActive(false);
    }
    public void MyButtenOnClick()
    {
        if (canActive)
        {
            manager.canActive_My = false;
            myHamsterUi.SetActive(true);
            UiChange_Manager.forWard = true;
        }
        
    }

    public void ShopButtenOnClick()
    {
        if (canActive)
        {
            manager.canActive_Shop = false;
            shop_Ui[0].SetActive(true);
            shop_Ui[1].SetActive(true);
            shop_Ui[2].SetActive(true);
            shop_Ui[3].SetActive(true);
            shop_Ui[4].SetActive(true);
        }
        
    }
    public void Shop_XButten()
    {
        manager.canActive_Shop = true;
        shop_Ui[0].SetActive(false);
        shop_Ui[1].SetActive(false);
        shop_Ui[2].SetActive(false);
        shop_Ui[3].SetActive(false);
        shop_Ui[4].SetActive(false);
        Shop_DishOnClick();
    }

    public void Shop_DishOnClick()
    {
        shopCanvas[0].sortingOrder = 105;
        shopCanvas[1].sortingOrder = 104;
        shopCanvas[2].sortingOrder = 103;
        shopCanvas[3].sortingOrder = 102;
        Debug.Log("클릭됨");
    }
    public void Shop_WaterBowlOnClick()
    {
        shopCanvas[0].sortingOrder = 104;
        shopCanvas[1].sortingOrder = 105;
        shopCanvas[2].sortingOrder = 103;
        shopCanvas[3].sortingOrder = 102;
        Debug.Log("클릭됨");
    }
    public void Shop_SandOnClick()
    {
        shopCanvas[0].sortingOrder = 103;
        shopCanvas[1].sortingOrder = 104;
        shopCanvas[2].sortingOrder = 105;
        shopCanvas[3].sortingOrder = 102;
        Debug.Log("클릭됨");
    }
    public void Shop_RurrerOnClick()
    {
        shopCanvas[0].sortingOrder = 102;
        shopCanvas[1].sortingOrder = 103;
        shopCanvas[2].sortingOrder = 104;
        shopCanvas[3].sortingOrder = 105;
        Debug.Log("클릭됨");
    }
}
