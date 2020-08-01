using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int id;
    public bool iHave;

    public bool randomNumCanActive;
    public bool hamsterIsMovingToFood;
    public bool barrierUp;
    public bool barrierDawn;
    public bool barrierLeft;
    public bool barrierRight;


    bool voidUpdateOnce1 = true;
    bool voidUpdateOnce2 = true;


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

    public SpriteRenderer hamsterSprite; 

    [SerializeField] bool dishIsClosedByHamSter;


    public int barrierNum;
    public int randomNum;
    public float randomTime;
    public float dD_CoolTime;
    [SerializeField] float eatingTime;



    public bool isLeft;

    public Animator ani;

    [SerializeField] GameObject eatingPos;
    [SerializeField] GameObject drinkingPos;

    public GameObject ddPrefap;
    public GameObject hamster;


    public Think_Sprite thinkScript;
    public DishScript dishScript;
    public WaterBowlScript waterbowlScript;

    [SerializeField] Sprite[] randomChangeSprite;
    public Sprite hamster_Thumbnail;



    public HamsterUi_Manager Uimanager;
    private void Start()
    {
        StartCoroutine("RandomMoving");
        StartCoroutine("DDtime");

        iHave = true;
        
    }
    public IEnumerator RandomMoving()
    {
        randomNum = Random.Range(1, 11);
        randomTime = Random.Range(3, 5);

        if (thirsty < thirstyToDrink)//목마를때
        {
            iamThirsty = true;
        }
        if(hunger < hungerToFeed)//배고플때
        {
            iamHungry = true;
        }


        if (randomNum == 10 && randomNumCanActive == true && hamsterIsMovingToFood == false)
        {
            randomTime = 5;
            ani.SetBool(" Interaction1Start", true);
            yield return new WaitForSeconds(randomTime);
            ani.SetBool(" Interaction1Start", false);
            randomTime = 0;

        }
        yield return new WaitForSeconds(randomTime);

        voidUpdateOnce1 = true;
        voidUpdateOnce2 = true;

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





    IEnumerator DrinkWater()
    {
        waterbowlScript.waterGauge -= 1;
        thirsty += watercalorie;
        if (thirsty > 100) thirsty = 100;
        yield return new WaitForSeconds(eatingTime);
        voidUpdateOnce1 = true;
        Debug.Log("물 마심");
    }
    IEnumerator EatFood()
    {
        dishScript.isFull = false;
        hunger += foodcalorie;
        if (hunger > 100) hunger = 100;
        yield return new WaitForSeconds(eatingTime);

        Debug.Log("먹이 먹음");
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
        Uimanager.hamster_Hunger = hunger;
        Uimanager.hamster_Thirsty = thirsty;
        Uimanager.hamster_Sprite.color = hamsterSprite.color;
        Uimanager.hamsterThumbnail = hamster_Thumbnail;

        hunger -= Time.deltaTime * 0.3f;
        thirsty -= Time.deltaTime * 0.3f;

        

        //물통으로 이동
        if (iamThirsty == true && waterbowlScript.waterGauge > 0)
        {
            hamsterIsMovingToFood = true;
            
            if (hamster.transform.position.x > drinkingPos.transform.position.x)
            {
                isLeft = true;
            }
            else
            {
                isLeft = false;
            }
            ani.SetBool("isStop", false);
            
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            hamster.transform.position = Vector3.MoveTowards(transform.position, drinkingPos.transform.position, Time.deltaTime * 1);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Debug.Log("물통으로 이동");

            if (transform.position == drinkingPos.transform.position && voidUpdateOnce1 == true)//물통에 닿음
            {
                voidUpdateOnce1 = false;
            //    Debug.Log("물통에 닿음");

                iamThirsty = false;

                StartCoroutine("DrinkWater");
            }
        }
        //먹이로 이동
        else if (iamHungry == true && dishScript.isFull == true)
        {
            hamsterIsMovingToFood = true;
            
            if (hamster.transform.position.x > eatingPos.transform.position.x)
            {
                isLeft = true;
            }
            else
            {
                isLeft = false;
            }

            ani.SetBool("isStop", false);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            hamster.transform.position = Vector3.MoveTowards(transform.position, eatingPos.transform.position, Time.deltaTime * 1);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Debug.Log("먹이로 이동");

            if (transform.position == eatingPos.transform.position && voidUpdateOnce2 == true)//먹이에 닿음
            {
                voidUpdateOnce2 = false;
            //    Debug.Log("먹이에 닿음");

                iamHungry = false;
 
                StartCoroutine("EatFood");
            }
        }
        else
        {
            hamsterIsMovingToFood = false;

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
           
            if(randomNumCanActive == true && hamsterIsMovingToFood == false)
            {
                if (randomNum == 1)//Idle
                {
                    transform.position += (new Vector3(0, 0));
                    ani.SetBool("isStop", true);
                //    Debug.Log("가만히");
                }
                if (randomNum == 2)//Up
                {
                    transform.position += (new Vector3(0, speed));
                    ani.SetBool("isStop", false);
                //    Debug.Log("위");
                }
                if (randomNum == 3)//Dawn
                {
                    transform.position += (new Vector3(0, -speed));
                    ani.SetBool("isStop", false);
                 //   Debug.Log("아래");
                }
                if (randomNum == 4)//Right
                {
                    transform.position += (new Vector3(speed, 0));
                    ani.SetBool("isStop", false);
                    isLeft = false;
                //    Debug.Log("오른쪽");
                }
                if (randomNum == 5)//Left
                {
                    transform.position += (new Vector3(-speed, 0));
                    ani.SetBool("isStop", false);
                    isLeft = true;
                //    Debug.Log("왼쪽");
                }
                if (randomNum == 6)//Up.Left
                {
                    transform.position += (new Vector3(-speed, speed));
                    ani.SetBool("isStop", false);
                    isLeft = true;
                //    Debug.Log("위,왼쪽");
                }
                if (randomNum == 7)//Up.Right
                {
                    transform.position += (new Vector3(speed, speed));
                    ani.SetBool("isStop", false);
                    isLeft = false;
                 //   Debug.Log("위,오른쪽");
                }
                if (randomNum == 8)//Dawn.Left
                {
                    transform.position += (new Vector3(-speed, -speed));
                    ani.SetBool("isStop", false);
                    isLeft = true;
                  //  Debug.Log("아래,왼쪽");
                }
                if (randomNum == 9)//Dawn.Right
                {
                    transform.position += (new Vector3(speed, -speed));
                    ani.SetBool("isStop", false);
                    isLeft = false;
                  //  Debug.Log("아래,오른쪽");
                }
            }
        }
            

        //햄스터 크기 반전
        if (isLeft == true)
        {
            transform.localScale = new Vector3(1, 1);
        }
        if (isLeft == false)
        {
            transform.localScale = new Vector3(-1, 1);
        }
    }
}
