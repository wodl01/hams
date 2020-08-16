using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtenUiManagerScript : MonoBehaviour
{
    [SerializeField] Ui_ChangeManager UiChange_Manager;
    [SerializeField] GameObject myHamsterUi;

    [SerializeField] GameObject[] shop_Ui;
    [SerializeField] Canvas[] shopCanvas;

    [SerializeField] dongScript manager;

    [SerializeField] Text shopMenuText;
    public bool canActive;
    public bool shop_CanActive;

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

            shopMenuText.text = "가구&소품";

            shop_Ui[0].SetActive(true);
            shop_Ui[1].SetActive(true);
            shop_Ui[2].SetActive(true);
            shop_Ui[3].SetActive(true);
            shop_Ui[4].SetActive(true);
            shop_Ui[5].SetActive(false);
            shop_Ui[6].SetActive(false);
        }
        
    }
    public void Shop_First_Page()
    {
        if (shop_CanActive)
        {
            manager.canActive_Shop = false;

            shopMenuText.text = "가구&소품";

            shop_Ui[1].SetActive(true);
            shop_Ui[2].SetActive(true);
            shop_Ui[3].SetActive(true);
            shop_Ui[4].SetActive(true);
            shop_Ui[5].SetActive(false);
            shop_Ui[6].SetActive(false);
        }
    }
    public void Shop_Second_Page()
    {
        if (shop_CanActive)
        {
            manager.canActive_Shop = false;

            shopMenuText.text = "배경";

            shop_Ui[1].SetActive(false);
            shop_Ui[2].SetActive(false);
            shop_Ui[3].SetActive(false);
            shop_Ui[4].SetActive(false);
            shop_Ui[5].SetActive(true);
            shop_Ui[6].SetActive(true);
        }
    }
    public void Shop_XButten()
    {
        if (shop_CanActive)
        {
            manager.canActive_Shop = true;
            shop_Ui[0].SetActive(false);
            shop_Ui[1].SetActive(false);
            shop_Ui[2].SetActive(false);
            shop_Ui[3].SetActive(false);
            shop_Ui[4].SetActive(false);
            shop_Ui[5].SetActive(false);
            shop_Ui[6].SetActive(false);
            Shop_DishOnClick();
        }
        
    }

    public void Shop_DishOnClick()
    {
        if (shop_CanActive)
        {
            shopCanvas[0].sortingOrder = 105;
            shopCanvas[1].sortingOrder = 104;
            shopCanvas[2].sortingOrder = 103;
            shopCanvas[3].sortingOrder = 102;
            Debug.Log("클릭됨");
        }
        
    }
    public void Shop_WaterBowlOnClick()
    {
        if (shop_CanActive)
        {
            shopCanvas[0].sortingOrder = 104;
            shopCanvas[1].sortingOrder = 105;
            shopCanvas[2].sortingOrder = 103;
            shopCanvas[3].sortingOrder = 102;
        }
        
        Debug.Log("클릭됨");
    }
    public void Shop_SandOnClick()
    {
        if (shop_CanActive)
        {
            shopCanvas[0].sortingOrder = 103;
            shopCanvas[1].sortingOrder = 104;
            shopCanvas[2].sortingOrder = 105;
            shopCanvas[3].sortingOrder = 102;
        }
        
        Debug.Log("클릭됨");
    }
    public void Shop_RurrerOnClick()
    {
        if (shop_CanActive)
        {
            shopCanvas[0].sortingOrder = 102;
            shopCanvas[1].sortingOrder = 103;
            shopCanvas[2].sortingOrder = 104;
            shopCanvas[3].sortingOrder = 105;
        }
        
        Debug.Log("클릭됨");
    }
    public void Shop_BeddingOnClick()
    {
        if (shop_CanActive)
        {
            shopCanvas[4].sortingOrder = 103;
            shopCanvas[5].sortingOrder = 102;
        }
    }
    public void Shop_WallPaperOnClick()
    {
        if (shop_CanActive)
        {
            shopCanvas[4].sortingOrder = 102;
            shopCanvas[5].sortingOrder = 103;
        }
    }
}
