using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dongScript : MonoBehaviour
{
    public Camera maincamera;

    public GameObject CoinPrefap;

    GameObject imform;
    [SerializeField] imformScript imformscript;

    GameObject dish;
    [SerializeField] DishScript dishscript;

    GameObject waterbowl;
    [SerializeField] WaterBowlScript waterBowlScript;

    public int ddGoldRate = 20;
    public int ddNormalRate = 80;

    public int ddGold;
    public int ddNormal;


    public int score;
    public Text scoreText;

    private void Start()
    {
        imform = GameObject.Find("Imform");
        imformscript = imform.GetComponent<imformScript>();
        dish = GameObject.Find("dish");
        dishscript = dish.GetComponent<DishScript>();
        waterbowl = GameObject.Find("waterbowl");
        waterBowlScript = waterbowl.GetComponent<WaterBowlScript>();
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
        imformscript.Coin += 3;
        Destroy(hit.transform.gameObject);
        Instantiate(CoinPrefap, hit.transform.position, Quaternion.identity);
        

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
        if(waterBowlScript.waterGauge == 0)
        {
            waterBowlScript.waterGauge = 4;
        }
    }
}



