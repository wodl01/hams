using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtenUiManagerScript : MonoBehaviour
{
    [SerializeField] Ui_ChangeManager Manager;
    [SerializeField] GameObject myHamsterUi;

    [SerializeField] GameObject[] shop_Ui;
    [SerializeField] Canvas[] shopCanvas;

    public void Xbutten()
    {
        Manager.stage = 1;
        myHamsterUi.SetActive(false);
    }
    public void MyButtenOnClick()
    {
        myHamsterUi.SetActive(true);
        Manager.forWard = true;
    }

    public void ShopButtenOnClick()
    {
        shop_Ui[0].SetActive(true);
        shop_Ui[1].SetActive(true);
        shop_Ui[2].SetActive(true);
        shop_Ui[3].SetActive(true);
        shop_Ui[4].SetActive(true);
    }
    public void Shop_XButten()
    {
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
