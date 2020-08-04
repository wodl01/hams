using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishCoinEffect : MonoBehaviour
{
    public float UpForce;

    public float TimeToReset;
    [SerializeField] bool once;


    public DishScript dish;

    public GameObject originalPos;

    public GameObject me;
    void Reset1()//다시 제자리로
    {
        me.SetActive(false);
        gameObject.transform.position = new Vector3(originalPos.transform.position.x,originalPos.transform.position.y);
        TimeToReset = 1;
        once = true;
    }
    private void Update()
    {

        TimeToReset -= Time.deltaTime;
        if (TimeToReset < 0 && once == true)
        {
            Debug.Log("이예ㅖㅖㅖ");
            once = false;
            Reset1();
        }


        gameObject.transform.position += new Vector3(0, UpForce, 0);
    }
}
