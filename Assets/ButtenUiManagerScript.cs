using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtenUiManagerScript : MonoBehaviour
{
    public Ui_ChangeManager Manager;
    public GameObject myHamsterUi;


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
