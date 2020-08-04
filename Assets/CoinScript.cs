using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float UpForce;

    public float TimeToDelete;


    public GameObject parent;


    private void Update()
    {

        TimeToDelete -= Time.deltaTime;
        if(TimeToDelete < 0)
        {
            Destroy(parent);
        }


        gameObject.transform.position += new Vector3(0, UpForce, 0);
    }
}
