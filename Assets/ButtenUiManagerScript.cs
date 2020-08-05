using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtenUiManagerScript : MonoBehaviour
{
    [SerializeField] Ui_ChangeManager Manager;
    [SerializeField] GameObject myHamsterUi;


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

}
