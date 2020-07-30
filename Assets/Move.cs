using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool randomNumCanActive;
    public bool barrierUp;
    public bool barrierDawn;
    public bool barrierLeft;
    public bool barrierRight;


    public float speed;
    public float hunger;
    public int hungerToFeed;
    public float thirsty;
    public int thirstyToDrink;
    public int foodcalorie;
    public int watercalorie;
    public bool isGoingtoDish;
    public bool iamHungry;
    public bool iamThirsty;

    [SerializeField] bool dishIsClosedByHamSter;


    public int barrierNum;
    public int randomNum;
    public float randomTime;
    public float dD_CoolTime;
    [SerializeField] float eatingTime;



    public float inputHereNowScale;

    public bool isLeft;

    public Animator ani;


    [SerializeField] GameObject dish;
    [SerializeField] GameObject waterbowl;
    public GameObject ddPrefap;
    public GameObject hamster;

    [SerializeField] GameObject think_Icon;
    Think_Sprite thinkScript;


    [SerializeField] Sprite[] randomChangeSprite;

    [SerializeField] DishScript dishScript;
    [SerializeField] WaterBowlScript waterbowlScript;
    private void Start()
    {
        StartCoroutine("RandomMoving");
        StartCoroutine("DDtime");

        dish = GameObject.Find("dish");
        waterbowl = GameObject.Find("waterbowl");


        thinkScript = think_Icon.GetComponent<Think_Sprite>();
        dishScript = dish.GetComponent<DishScript>();
        waterbowlScript = waterbowl.GetComponent<WaterBowlScript>();
    }
    public IEnumerator RandomMoving()
    {
        randomNum = Random.Range(1, 11);
        randomTime = Random.Range(3, 5);
        if (thirsty < thirstyToDrink && waterbowlScript.waterGauge > 0)
        {
            iamThirsty = true;
            ani.SetBool("isStop", false);
            if (hamster.transform.position.x > dish.transform.position.x)
            {
                isLeft = true;
            }
            else
            {
                isLeft = false;
            }
        }
        else if(hunger < hungerToFeed && dishScript.isFull == true)
        {
            iamHungry = true;
            ani.SetBool("isStop", false);
            if (hamster.transform.position.x > dish.transform.position.x)
            {
                isLeft = true;
            }
            else
            {
                isLeft = false;
            }
        }

        

        if (randomNum == 10 && randomNumCanActive == true)
        {
            randomTime = 5;
            ani.SetBool(" Interaction1Start", true);
            yield return new WaitForSeconds(randomTime);
            ani.SetBool(" Interaction1Start", false);
            randomTime = 0;

        }
        yield return new WaitForSeconds(randomTime);
        

        StartCoroutine("RandomMoving");

    }


    public IEnumerator StopMove()
    {
        barrierNum = 0;
        randomNumCanActive = false;
        Debug.Log("방벽에 닿아 멈춤");
        yield return new WaitForSeconds(3);

        

        if (barrierUp == true)
        {

            barrierNum = 1;

        }
        if (barrierDawn == true)
        {

            barrierNum = 2;

        }
        if (barrierRight == true)
        {

            barrierNum = 3;

        }
        if (barrierLeft == true)
        {

            barrierNum = 4;

        }
        barrierUp = false;
        barrierDawn = false;
        barrierLeft = false;
        barrierRight = false;
        yield return new WaitForSeconds(3);
        barrierNum = 5;
        randomNumCanActive = true;
    }






    IEnumerator EatFood()
    {
        dishScript.isFull = false;
        hunger += foodcalorie;
        if (hunger > 100) hunger = 100;
        yield return new WaitForSeconds(eatingTime);
        Debug.Log("먹이 먹음");
    }
    IEnumerator DrinkWater()
    {
        waterbowlScript.waterGauge -= 1;
        thirsty += watercalorie;
        if (thirsty > 100) thirsty = 100;
        yield return new WaitForSeconds(eatingTime);
    }





    void DD()
    {
        
        Instantiate(ddPrefap, gameObject.transform.position, Quaternion.identity);
        ddPrefap.GetComponent<SpriteRenderer>().sprite = randomChangeSprite[Random.Range(0, randomChangeSprite.Length)];
    }
    IEnumerator DDtime()
    {
        yield return new WaitForSeconds(dD_CoolTime);
        DD();
        StartCoroutine("DDtime");
    }
    //새로 방벽에 닿았을때 움직이는걸 만들고 그떄까지는 randomnum이 실행하는 업데이트 함수를 안움직이게 그냥 막아버리고 벽에닿고 다움직이면 그때 그냥 풀어준다



    void ThinkIconUp()
    {
        thinkScript.HamsterIsBottom = false;
    }
    void ThinkIconDawn()
    {
        thinkScript.HamsterIsBottom = true;
    }
    void Update()
    {

        hunger -= Time.deltaTime * 0.3f;
        thirsty -= Time.deltaTime * 0.3f;



        //물통으로 이동
        if (iamThirsty == true && waterbowlScript.waterGauge > 0)
        {

            hamster.transform.position = Vector3.MoveTowards(transform.position, waterbowl.transform.position, Time.deltaTime * 1);

            Debug.Log("물통으로 이동");

            if (transform.position == waterbowl.transform.position)
            {
                Debug.Log("물통에 닿음");
                iamHungry = false;

                StartCoroutine("DrinkWater");
            }
        }
        //먹이로 이동
        else if (iamHungry == true && dishScript.isFull == true)
        {

            hamster.transform.position = Vector3.MoveTowards(transform.position, dish.transform.position, Time.deltaTime * 1);

            Debug.Log("먹이로 이동");

            if (transform.position == dish.transform.position)
            {
                Debug.Log("먹이에 닿음");
                iamHungry = false;
  
                StartCoroutine("EatFood");
            }
        }
        else
        {
            if (barrierNum == 0)
            {
                ani.SetBool("isStop", true);
            }

            if (barrierNum == 1)
            {
                transform.position += (new Vector3(0, -speed));//아래
                ani.SetBool("isStop", false);
            }
            if (barrierNum == 2)
            {
                transform.position += (new Vector3(0, speed));//위
                ani.SetBool("isStop", false);
            }
            if (barrierNum == 3)
            {
                transform.position += (new Vector3(-speed, 0));//왼쪽
                ani.SetBool("isStop", false);
                isLeft = true;
            }
            if (barrierNum == 4)
            {
                transform.position += (new Vector3(speed, 0));//오른쪽
                ani.SetBool("isStop", false);
                isLeft = false;
            }

            /////////////////////////////////////////////////////////////////////////////////////



            /////////////////////////////////////////////////////////////////////////////////////
           

            if (randomNum == 1 && randomNumCanActive == true)//Idle
            {
                transform.position += (new Vector3(0, 0));
                ani.SetBool("isStop", true);
                Debug.Log("가만히");
            }
            if (randomNum == 2 && randomNumCanActive == true)//Up
            {
                transform.position += (new Vector3(0, speed));
                ani.SetBool("isStop", false);
                Debug.Log("위");
            }
            if (randomNum == 3 && randomNumCanActive == true)//Dawn
            {
                transform.position += (new Vector3(0, -speed));
                ani.SetBool("isStop", false);
                Debug.Log("아래");
            }
            if (randomNum == 4 && randomNumCanActive == true)//Right
            {
                transform.position += (new Vector3(speed, 0));
                ani.SetBool("isStop", false);
                isLeft = false;
                Debug.Log("오른쪽");
            }
            if (randomNum == 5 && randomNumCanActive == true)//Left
            {
                transform.position += (new Vector3(-speed, 0));
                ani.SetBool("isStop", false);
                isLeft = true;
                Debug.Log("왼쪽");
            }
            if (randomNum == 6 && randomNumCanActive == true)//Up.Left
            {
                transform.position += (new Vector3(-speed, speed));
                ani.SetBool("isStop", false);
                isLeft = true;
                Debug.Log("위,왼쪽");
            }
            if (randomNum == 7 && randomNumCanActive == true)//Up.Right
            {
                transform.position += (new Vector3(speed, speed));
                ani.SetBool("isStop", false);
                isLeft = false;
                Debug.Log("위,오른쪽");
            }
            if (randomNum == 8 && randomNumCanActive == true)//Dawn.Left
            {
                transform.position += (new Vector3(-speed, -speed));
                ani.SetBool("isStop", false);
                isLeft = true;
                Debug.Log("아래,왼쪽");
            }
            if (randomNum == 9 && randomNumCanActive == true)//Dawn.Right
            {
                transform.position += (new Vector3(speed, -speed));
                ani.SetBool("isStop", false);
                isLeft = false;
                Debug.Log("아래,오른쪽");
            }
        }

        //햄스터 크기 반전
        if (isLeft == true)
        {
            transform.localScale = new Vector3(inputHereNowScale, inputHereNowScale);
        }
        if (isLeft == false)
        {
            transform.localScale = new Vector3(-inputHereNowScale, inputHereNowScale);
        }
    }
}
