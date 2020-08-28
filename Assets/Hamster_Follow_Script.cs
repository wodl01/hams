using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Hamster_Follow_Script : MonoBehaviour
{
    //[SerializeField] GameObject[] hamster;
    [SerializeField] Transform pointer;
    [SerializeField] GameObject[] hamsters;
    Vector3 positions;
    GameObject target;
    float tempX;
    float tempY;
    public Move hamsterScript;
    [SerializeField] AIPath hamster_Ai_Script;
    [SerializeField] AIDestinationSetter hamster_Ai_Script2;


    public float deleteTime;

    public void Check()
    {
        tempX = 100;
        tempY = 100;

        foreach (GameObject hams in hamsters)
        {
            Debug.Log("hi");
            positions = pointer.position - hams.transform.position;
            Debug.Log(positions);
            if (Mathf.Abs(positions.x) < Mathf.Abs(tempX))
            {
                Debug.Log(hams.gameObject.name + "는 통과1");
                if (Mathf.Abs(positions.y) < Mathf.Abs(tempY))
                {
                    Debug.Log(hams.gameObject.name + "는 통과2");

                    tempX = positions.x;
                    tempY = positions.y;
                    Debug.Log(hams.gameObject.name + "제일가까움");
                    target = hams;
                    Debug.Log(target);
                }
            }
        }
        hamsterScript = target.GetComponent<Move>();
        hamster_Ai_Script = target.GetComponent<AIPath>();
        hamster_Ai_Script2 = target.GetComponent<AIDestinationSetter>();


        hamsterScript.isGoingtoPointer = true;


    }
    private void FixedUpdate()
    {
        
        if(gameObject.transform.position == target.transform.position)//닿았을때
        {
            hamsterScript.isGoingtoPointer = false;
            hamster_Ai_Script2.target = null;
            hamster_Ai_Script.canMove = false;

            gameObject.SetActive(false);
            Debug.Log("포인트에 닿음");
        }
        if(deleteTime < 0)//시간이 오래 지났을때
        {
            hamsterScript.isGoingtoPointer = false;
                        hamster_Ai_Script2.target = null;
            hamster_Ai_Script.canMove = false;

            gameObject.SetActive(false);
        }
        /*if (gameObject.activeSelf)
        {
            Debug.Log("켜짐");
        }*/
        deleteTime -= Time.deltaTime;
    }
}
