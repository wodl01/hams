using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_ChangeManager : MonoBehaviour
{
    public Move[] code;

    public bool forWard;
    public bool backWard;

    public bool forWardOk;
    public bool backWardOk;

    public GameObject[] imformation;


    public int stage;

   // [SerializeField] int maxStageNum;
    public void PlusOnce()
    {
        stage += 1;
        forWard = true;
    }

    public void MinusOnce()
    {
        stage -= 1;
        backWard = true;
    }



    private void Update()
    {
        if (stage > imformation.Length)//앞으로
        {
            stage = 1;
        }

        if(stage == 0)
        {
            stage = imformation.Length;
        }


        if (forWard)//앞으로
        {

            if (stage == 1 && code[0].iHave == true)
            {
                for (int i = 0; i < imformation.Length; i++)
                {
                    imformation[i].SetActive(false);
                }
                imformation[0].SetActive(true);
                forWardOk = true;



            }
            else if (stage == 1 && code[0].iHave == false)
            {
                stage++;

            }


            if (stage == 2 && code[1].iHave == true)
            {
                for (int i = 0; i < imformation.Length; i++)
                {
                    imformation[i].SetActive(false);
                }
                imformation[1].SetActive(true);
                forWardOk = true;

            }
            else if (stage == 2 && code[1].iHave == false)
            {
                stage++;

            }


            if (stage == 3 && code[2].iHave == true)
            {
                for (int i = 0; i < imformation.Length; i++)
                {
                    imformation[i].SetActive(false);
                }
                imformation[2].SetActive(true);
                forWardOk = true;

            }
            else if (stage == 3 && code[2].iHave == false)
            {
                stage++;

            }

            if (forWardOk)
            {
                forWard = false;
                forWardOk = false;
            }
            



        }



        if (backWard)//뒤로
        {
            if (stage == 3 && code[2].iHave == true)
            {
                for (int i = 0; i < imformation.Length; i++)
                {
                    imformation[i].SetActive(false);
                }
                imformation[2].SetActive(true);
                backWardOk = true;

            }
            else if (stage == 3 && code[2].iHave == false)
            {
                stage--;

            }


            if (stage == 2 && code[1].iHave == true)
            {
                for (int i = 0; i < imformation.Length; i++)
                {
                    imformation[i].SetActive(false);
                }
                imformation[1].SetActive(true);
                backWardOk = true;

            }
            else if (stage == 2 && code[1].iHave == false)
            {
                stage--;

            }


            if (stage == 1 && code[0].iHave == true)//앞으로
            {
                for (int i = 0; i < imformation.Length; i++)
                {
                    imformation[i].SetActive(false);
                }
                imformation[0].SetActive(true);
                backWardOk = true;


            }
            else if (stage == 1 && code[0].iHave == false)
            {
                stage = imformation.Length;
            }

            if (backWardOk)
            {
                backWard = false;
                backWardOk = false;
            }
            


        }
    }
}
