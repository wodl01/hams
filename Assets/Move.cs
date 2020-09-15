using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Move : MonoBehaviour
{
    public string name;
    public bool isNamed;
    public bool iHave;
    public int cageNum;

    [SerializeField] bool canMove;

    public int ddGoldRate;
    public int ddValue;//1
    public float dD_CoolTime;

    public int percent;

    public bool randomNumCanActive;
    public bool hamsterIsMovingToOB;
    public bool barrierUp;
    public bool barrierDawn;
    public bool barrierLeft;
    public bool barrierRight;
    public bool isPropBarrier;
    [SerializeField] float barrierWaitTime;
    [SerializeField] bool eatingFood;
    [SerializeField] bool eatingWater;


    bool voidUpdateOnce1 = true;
    bool voidUpdateOnce2 = true;

    public int hamsterLv;//1
    public float hamsterIntimacy;
    public int hamsterStressValue;
    public float speed;
    public float hunger;

    [SerializeField] float cleanTime;

    public int hungerToFeed;
    public float thirsty;
    public int thirstyToDrink;
    public int foodcalorie;
    public int watercalorie;
    public float tiredValue;
    public float timeToSleep;
    public bool isSleep;
    bool bathing;
    [SerializeField] bool isEmoting;

    public bool isGoingtoPointer;
    public bool iamHungry;
    public bool iamThirsty;
    [SerializeField]bool isClean;

    public SpriteRenderer hamsterSprite;


    [SerializeField] bool dishIsClosedByHamSter;

    public int barrierNum;
    public int randomNum;
    public float randomTime;

    [SerializeField] float eatingTime;

    [SerializeField] bool isLeft;

    public Animator ani;

    [SerializeField] Transform bathingPos;

    [SerializeField] GameObject bath;

    [SerializeField] GameObject eatingPos;
    [SerializeField] GameObject drinkingPos;
    [SerializeField] GameObject pointPos;
    [SerializeField] GameObject bathPos;

    public GameObject ddPrefap;
    public GameObject goldenDDPrefap;
    public GameObject hamsterNameUi;


    public Think_Sprite thinkScript;
    public DishScript dishScript;
    public WaterBowlScript waterbowlScript;
    public DDMoneyScript GDDMoneyScript;
    public DDMoneyScript NDDMoneyScript;
    public dongScript manager;
    public ButtenUiManagerScript buttenUiManager;
    [SerializeField] AIDestinationSetter aiScript;
    [SerializeField] AIPath aiPath;

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

        if (tiredValue <= timeToSleep && !eatingFood && !eatingWater && randomNumCanActive && !hamsterIsMovingToOB)
        {
            isSleep = true;
        }

        if (thirsty < thirstyToDrink && !isSleep)//목마를때
        {
            iamThirsty = true;
        }
        if(hunger < hungerToFeed && !isSleep)//배고플때
        {
            iamHungry = true;
        }
        if(cleanTime < 0 && !isSleep)
        {
            int a = Random.Range(1, 4);//1~3
            if(a == 1 || a == 2 || a == 3)
            {
                isClean = false;
            }
            else
            {
                cleanTime = 60;
            }
            
        }

        if (randomNum == 10 && randomNumCanActive && !hamsterIsMovingToOB && !eatingFood && !eatingWater && !isGoingtoPointer && !isSleep)
        {
            randomTime = 5;            
            ani.SetBool(" Interaction1Start", true);
            isEmoting = true;
            canMove = false;
            yield return new WaitForSeconds(randomTime);
            ani.SetBool(" Interaction1Start", false);
            isEmoting = false;
            randomTime = 0;

        }
        yield return new WaitForSeconds(randomTime);

        voidUpdateOnce1 = true;
        voidUpdateOnce2 = true;

        StartCoroutine("RandomMoving");

    }


    public void CanMove()
    {
        canMove = true;
    }

    public IEnumerator StopMove()
    {
        
        barrierNum = 0;
        randomNumCanActive = false;
        if (isPropBarrier) barrierWaitTime = 0.5f;
        else barrierWaitTime = 3;
        Debug.Log("방벽에 닿아 멈춤");
        yield return new WaitForSeconds(barrierWaitTime);

        

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
        yield return new WaitForSeconds(barrierWaitTime);
        barrierNum = 5;
        isPropBarrier = false;
        randomNumCanActive = true;
    }





    IEnumerator DrinkWater()
    {
        waterbowlScript.waterGauge -= 1;
        thirsty += watercalorie;
        if (thirsty > 100) thirsty = 100;
        //애니메이션

        
        yield return new WaitForSeconds(eatingTime);
        eatingWater = false;
        voidUpdateOnce1 = true;
        Debug.Log("물 마심");
    }
    IEnumerator EatFood()
    {
        dishScript.isFull = false;
        hunger += foodcalorie;
        if (hunger > 100) hunger = 100;
        //애니메이션

        
        yield return new WaitForSeconds(eatingTime);
        eatingFood = false;

        Debug.Log("먹이 먹음");
    }
    IEnumerator Bathing()
    {
        Debug.Log("dldoeoelwlwos");
        isClean = true;
        cleanTime = 60;
        gameObject.transform.position = bathingPos.position;
        canMove = false;
        ani.SetBool("IsBath", true);
        yield return new WaitForSeconds(5);
        gameObject.transform.position = bathPos.transform.position;
        ani.SetBool("IsBath", false);
        ani.SetBool("isStop", false);
        bathing = false;
    }






    void DD()
    {

        bool isGold = false;

        percent = Random.Range(0, 100);
        if (percent <= ddGoldRate) isGold = true;



        if (isGold == false)//일반일떄
        {
            //형태변형
            
            //똥가치 설정
            NDDMoneyScript.hamsterLvMoney = ddValue;
            //일반생성
            Instantiate(ddPrefap, gameObject.transform.position, Quaternion.identity);


        }
        else//황금일때
        {
            //형태변경
            
            //똥가치 설정
            GDDMoneyScript.hamsterLvMoney = ddValue;
            //황금생성
            Instantiate(goldenDDPrefap, gameObject.transform.position, Quaternion.identity);


        }


        isGold = false;
    }
    IEnumerator DDtime()
    {
        yield return new WaitForSeconds(dD_CoolTime);
        DD();
        if (!isSleep)
        {
            StartCoroutine(DDtime());
        }
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "DrinkingPos" && voidUpdateOnce1 == true && hamsterIsMovingToOB && iamThirsty && waterbowlScript.waterGauge > 0)
        {
            voidUpdateOnce1 = false;
            Debug.Log("물마심");
            gameObject.transform.position = drinkingPos.transform.position;
            aiPath.canMove = false;


            hamsterIsMovingToOB = false;

            
            eatingWater = true;

            iamThirsty = false;

            StartCoroutine(DrinkWater());
            
        }
        if (other.tag == "EatingPos" && voidUpdateOnce1 == true && hamsterIsMovingToOB && iamHungry && dishScript.isFull)
        {
            voidUpdateOnce1 = false;
            Debug.Log("물마심");
            gameObject.transform.position = eatingPos.transform.position;
            aiPath.canMove = false;

            hamsterIsMovingToOB = false;
            eatingFood = true;

            iamHungry = false;

            StartCoroutine(EatFood());

        }
        if (other.tag == "BathPos" && voidUpdateOnce1 == true && hamsterIsMovingToOB && !isClean)
        {
            voidUpdateOnce1 = false;
            Debug.Log("목욕시간");
            gameObject.transform.position = bathPos.transform.position;
            aiPath.canMove = false;
            isLeft = true;
            hamsterIsMovingToOB = false;
            bathing = true;

            StartCoroutine(Bathing());

        }
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
        Uimanager.hamster_Name = name;
        Uimanager.hamster_Hunger = hunger;
        Uimanager.hamster_Thirsty = thirsty;
        Uimanager.hamster_Sprite.color = hamsterSprite.color;
        Uimanager.hamsterThumbnail = hamster_Thumbnail;
        Uimanager.hamster_Intimacy = hamsterIntimacy;
        Uimanager.hamster_Lv = hamsterLv;
        Uimanager.hamster_StressValue = hamsterStressValue;

        if (!isSleep)
        {
            hunger -= Time.deltaTime * 0.3f;
            thirsty -= Time.deltaTime * 0.3f;
            tiredValue -= Time.deltaTime * 0.1f;
            cleanTime -= Time.deltaTime;
        }


            dishScript = manager.dishscript[0];
            waterbowlScript = manager.waterBowlScript[0];
        assaaae



        //포인터로 이동
        if (!hamsterIsMovingToOB && randomNumCanActive && isGoingtoPointer && !isSleep && !eatingFood && !eatingWater && !bathing && !isEmoting)
        {

            aiScript.target = pointPos.transform;
            aiPath.canMove = true;
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                isLeft = false;
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                isLeft = true;
            }
            
        }




        if (isNamed == false)
        {
            buttenUiManager.canActive = false;
            manager.canActive_Name = false;
            hamsterNameUi.SetActive(true);
        }
        if(hamsterIntimacy > 100)
        {
            hamsterIntimacy = 100;
        }
        else if(hamsterIntimacy < 0)
        {
            hamsterIntimacy = 0;
        }
        if(isSleep)
        {
            ani.SetBool("IsSleep", true);
            canMove = false;
            tiredValue += Time.deltaTime * 0.4f;
            if(tiredValue > 100)
            {
                isSleep = false;
                ani.SetBool("IsSleep", false);
            }
        }

        //물통으로 이동
        if (iamThirsty && waterbowlScript.waterGauge > 0 && !eatingFood  && randomNumCanActive && !isSleep && !isEmoting)
        {
            hamsterIsMovingToOB = true;
            Debug.Log("물통으로간다");
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                isLeft = false;
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                isLeft = true;
            }

            ani.SetBool("isStop", false);
            aiScript.target = drinkingPos.transform;
            aiPath.canMove = true;    
        }
        //먹이로 이동
        else if (iamHungry && dishScript.isFull && !eatingWater && randomNumCanActive && !isSleep && !isEmoting)
        {
            hamsterIsMovingToOB = true;
            Debug.Log("먹이로간다");
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                isLeft = false;
            }
            else if(aiPath.desiredVelocity.x <= -0.01f)
            {
                isLeft = true;
            }
            aiScript.target = eatingPos.transform;
            aiPath.canMove = true;
            ani.SetBool("isStop", false);
            
        }
        else if (!isClean && !eatingWater && !eatingFood && randomNumCanActive && !isSleep && !isEmoting)
        {
            hamsterIsMovingToOB = true;
            Debug.Log("화장실에간다");
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                isLeft = false;
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                isLeft = true;
            }
            aiScript.target = bathPos.transform;
            aiPath.canMove = true;
            ani.SetBool("isStop", false);

        }


        else
        {
            if(!hamsterIsMovingToOB && !isGoingtoPointer)
            {
                if(!eatingFood && !eatingWater && !bathing)
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
                }
            }

            

            /////////////////////////////////////////////////////////////////////////////////////



            /////////////////////////////////////////////////////////////////////////////////////


            if (canMove && randomNumCanActive && !hamsterIsMovingToOB && !eatingFood && !eatingWater && !isGoingtoPointer && !isSleep && !bathing)
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
            //hamsterSprite.flipX = false;
        }
        if (isLeft == false)
        {
            transform.localScale = new Vector3(-1, 1);
            //hamsterSprite.flipX = true;
        }
    }
}
