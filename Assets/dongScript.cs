using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class dongScript : MonoBehaviour
{
    public Camera maincamera;
    Vector3 mousePos;
    [SerializeField] float time;
    float doubleClick_Cool_Time;
    [SerializeField] float coolTime;

    [SerializeField] GameObject doubleClickOB;

    public GameObject warningPreFap;


    [SerializeField] DishScript[] dishscript;

    [SerializeField] WaterBowlScript[] waterBowlScript;

    [SerializeField] WarningScript warning;

    [SerializeField] Hamster_Follow_Script followScript;

    [SerializeField] Move[] hamsterScript;

    public bool canActive_My;
    public bool canActive_Name;
    public bool canActive_Shop;

    public int score;
    public Text scoreText;
    public Text scoreTextInShop;

    [SerializeField] Transform[] cage_transform;

    public bool cage2;
    public bool cage3;

    [SerializeField] int cageNum;
    void Update()
    {
        scoreText.text = "    " + "<color=#000000>" + score + "</color>" + "@";
        scoreTextInShop.text = "    " + "<color=#000000>" + score + "</color>" + "@";
        


        if (canActive_My && canActive_Name && canActive_Shop)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                AstarPath.active.Scan();
            }

            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                Vector3 cameraPos = maincamera.transform.position;


                if (hit.collider != null)
                {
                    if (hit.collider.tag == "DD")
                    {
                        DdongEvent(hit);
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                Vector3 cameraPos = maincamera.transform.position;


                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Dish")
                    {
                        DishCage1();
                    }
                    if (hit.collider.tag == "Dish2")
                    {
                        DishCage2();
                    }
                    if (hit.collider.tag == "Dish3")
                    {
                        DishCage3();
                    }
                    if (hit.collider.tag == "WaterBowl")
                    {
                        WaterBowlCage1();
                    }
                    if (hit.collider.tag == "WaterBowl2")
                    {
                        WaterBowlCage2();
                    }
                    if (hit.collider.tag == "WaterBowl3")
                    {
                        WaterBowlCage3();
                    }
                }

            }


            if (Input.GetMouseButtonDown(0) && time <= 0)
            {
                mousePos = Input.mousePosition;
                mousePos = maincamera.ScreenToWorldPoint(mousePos);



                time = 0.2f;
                Debug.Log("1click");

            }
            else if (Input.GetMouseButtonDown(0) && time > 0 && doubleClick_Cool_Time < 0 )
            {
                //더블클릭
                //Instantiate(doubleClickOB, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
                Debug.Log("2click");
                doubleClickOB.SetActive(true);
                followScript.Check();

                doubleClickOB.transform.position = mousePos + new Vector3(0, 0, 10);
                if (doubleClickOB.transform.position.y > 1.13)
                {
                    doubleClickOB.SetActive(false);
                    followScript.hamsterScript.isGoingtoPointer = false;
                }
                doubleClick_Cool_Time = coolTime;
                followScript.deleteTime = 5;
            }
        }
    }
    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        doubleClick_Cool_Time -= Time.deltaTime;
    }
    void DdongEvent(RaycastHit2D hit)
    {
        GameObject go = hit.collider.gameObject;
    
        DDMoneyScript dDMoney = go.GetComponent<DDMoneyScript>();
        BoxCollider2D box = go.GetComponent<BoxCollider2D>();
        SpriteRenderer sprite = go.GetComponent<SpriteRenderer>();



        box.enabled = false;
        sprite.enabled = false;
        dDMoney.coinTextOB.SetActive(true);

        score += dDMoney.finalDDMoney;
        

    }

    public void Next()
    {
        if(cageNum == 1 && cage2 == true)
        {
            Debug.Log("케이지2");
            cageNum = 2;
            maincamera.transform.position = new Vector3(cage_transform[1].position.x , cage_transform[1].position.y , -10);
        }
        else if(cageNum == 2 && cage3 == true)
        {
            Debug.Log("케이지3");
            cageNum = 3;
            maincamera.transform.position = new Vector3(cage_transform[2].position.x, cage_transform[2].position.y, -10);
        }
        else if(cageNum == 3)
        {
            Debug.Log("케이지1");
            cageNum = 1;
            maincamera.transform.position = new Vector3(cage_transform[0].position.x, cage_transform[0].position.y, -10);
        }
    }

    public void Back()
    {
        if(cageNum == 1 && cage3 == true)
        {
            Debug.Log("케이지3");
            cageNum = 3;
            maincamera.transform.position = new Vector3(cage_transform[2].position.x, cage_transform[2].position.y, -10);
        }
        else if(cageNum == 3 && cage2 == true)
        {
            Debug.Log("케이지2");
            cageNum = 2;
            maincamera.transform.position = new Vector3(cage_transform[1].position.x, cage_transform[1].position.y, -10);
        }
        else if(cageNum == 2)
        {
            Debug.Log("케이지1");
            cageNum = 1;
            maincamera.transform.position = new Vector3(cage_transform[0].position.x, cage_transform[0].position.y, -10);
        }
    }

    void DishCage1()
    {
        if(dishscript[0].isFull == false)
        {
            Debug.Log("dwdw");
            if(score >= dishscript[0].feedValue)
            {
                score -= dishscript[0].feedValue;
                dishscript[0].MinusCoin();
                dishscript[0].isFull = true;
            }
            else
            {
                warning.InputWord = "코인이 부족합니다.";
                Instantiate(warningPreFap, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }

    void DishCage2()
    {
        if (dishscript[1].isFull == false)
        {
            Debug.Log("dwdw");
            if (score >= dishscript[1].feedValue)
            {
                score -= dishscript[1].feedValue;
                dishscript[1].MinusCoin();
                dishscript[1].isFull = true;
            }
            else
            {
                warning.InputWord = "코인이 부족합니다.";
                Instantiate(warningPreFap, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
    void DishCage3()
    {
        if (dishscript[2].isFull == false)
        {
            Debug.Log("dwdw");
            if (score >= dishscript[2].feedValue)
            {
                score -= dishscript[2].feedValue;
                dishscript[2].MinusCoin();
                dishscript[2].isFull = true;
            }
            else
            {
                warning.InputWord = "코인이 부족합니다.";
                Instantiate(warningPreFap, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
    void WaterBowlCage1()
    {
        Debug.Log("물통에 마우스가 닿음");
        if(waterBowlScript[0].waterGauge == 0)
        {
            waterBowlScript[0].waterGauge = 4;
        }
    }
    void WaterBowlCage2()
    {
        Debug.Log("물통에 마우스가 닿음");
        if (waterBowlScript[1].waterGauge == 0)
        {
            waterBowlScript[1].waterGauge = 4;
        }
    }
    void WaterBowlCage3()
    {
        Debug.Log("물통에 마우스가 닿음");
        if (waterBowlScript[2].waterGauge == 0)
        {
            waterBowlScript[2].waterGauge = 4;
        }
    }

}



