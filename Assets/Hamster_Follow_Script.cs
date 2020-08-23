using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster_Follow_Script : MonoBehaviour
{
    //[SerializeField] GameObject[] hamster;
    [SerializeField] Transform pointer;
    [SerializeField] GameObject[] hamsters;
    Vector3 positions;
    GameObject target;
    float tempX;
    float tempY;
    [SerializeField] Move hamsterScript;
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
        hamsterScript.isGoingtoPointer = true;
    }
    private void FixedUpdate()
    {

        if(gameObject.transform.position == target.transform.position)
        {
            hamsterScript.isGoingtoPointer = false;
            gameObject.SetActive(false);
        }
        if(deleteTime < 0)
        {
            hamsterScript.isGoingtoPointer = false;
            gameObject.SetActive(false);
        }
        deleteTime -= Time.deltaTime;
    }
}
