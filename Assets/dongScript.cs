using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dongScript : MonoBehaviour
{
    public Camera maincamera;
    Vector3 mousePos;
    [SerializeField] float time;
    float doubleClick_Cool_Time;
    [SerializeField] float coolTime;

    [SerializeField] GameObject doubleClickOB;

    public GameObject warningPreFap;


    [SerializeField] DishScript dishscript;

    [SerializeField] WaterBowlScript waterBowlScript;

    [SerializeField] WarningScript warning;

    [SerializeField] Hamster_Follow_Script followScript;

    [SerializeField] Move[] hamsterScript;

    public bool canActive_My;
    public bool canActive_Name;
    public bool canActive_Shop;

    public int score;
    public Text scoreText;
    public Text scoreTextInShop;


    void Update()
    {
        scoreText.text = "    " + "<color=#000000>" + score + "</color>" + "@";
        scoreTextInShop.text = "    " + "<color=#000000>" + score + "</color>" + "@";
        


        if (canActive_My && canActive_Name && canActive_Shop)
        {
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
                        Dish();
                    }
                    if (hit.collider.tag == "WaterBowl")
                    {
                        WaterBowl();
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
    void Dish()
    {
        if(dishscript.isFull == false)
        {
            Debug.Log("dwdw");
            if(score >= dishscript.feedValue)
            {
                score -= dishscript.feedValue;
                dishscript.MinusCoin();
                dishscript.isFull = true;
            }
            else
            {
                warning.InputWord = "코인이 부족합니다.";
                Instantiate(warningPreFap, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
    void WaterBowl()
    {
        Debug.Log("물통에 마우스가 닿음");
        if(waterBowlScript.waterGauge == 0)
        {
            waterBowlScript.waterGauge = 4;
        }
    }
}



