using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dongScript : MonoBehaviour
{
    public Camera maincamera;

    public GameObject CoinPrefap;




    public DishScript dishscript;

    public WaterBowlScript waterBowlScript;

    

    public int score;
    public Text scoreText;


    private void Start()
    {

    }

    void Update()
    {
        scoreText.text = "@"+ "    " + "<color=#000000>" + score + "</color>" ;

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            Vector3 cameraPos = maincamera.transform.position;
            if (hit.collider != null)
            {
                if (hit.collider.tag == "DD" || hit.collider.tag == "GoldenDD")
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
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            Vector3 cameraPos = maincamera.transform.position;
            if (hit.collider != null)
            {
                if (hit.collider.tag == "WaterBowl")
                {
                    WaterBowl();
                }
            }
        }
    }

    void DdongEvent(RaycastHit2D hit)
    {
        Debug.Log("djdjoeoeo11111111");
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
            dishscript.isFull = true;

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



