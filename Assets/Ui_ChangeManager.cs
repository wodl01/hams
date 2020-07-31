using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_ChangeManager : MonoBehaviour
{
    public Move[] code;
 


    public GameObject[] imformation;


    public int stage;

   // [SerializeField] int maxStageNum;

    private void Start()
    {
        TurnOnHamster();
   //     maxStageNum += 1;
    }
    public void PlusOnce()
    {
        stage += 1;
        AllFalse();
    }
    public void MinusOnce()
    {
        stage -= 1;
        AllFalse();
    }
    public void AllFalse() 
    {
        for (int i = 0; i < imformation.Length; i++)
        {
            imformation[i].SetActive(false);
        }
        if (stage > imformation.Length)
        {
            stage = 1;
        }
        TurnOnHamster();
    }
    public void TurnOnHamster()
    {
        if (stage == 1 && code[0].iHave == true)
        {
            imformation[0].SetActive(true);

            Debug.Log("11111");
            Debug.Log("첫번쨰 스테이지" + stage);
        }
        else if(code[0].iHave == false)
        {
            stage++;
            Debug.Log("스테이지 추가" + stage);
        }


        if (stage == 2 && code[1].iHave == true)
        {
            imformation[1].SetActive(true);
            Debug.Log("두번쨰 스테이지" + stage);
        }
        else if (code[1].iHave == false)
        {
            stage++;
            Debug.Log("스테이지 추가" + stage);
        }

     


    }

    private void Update()
    {
 

    }
}
