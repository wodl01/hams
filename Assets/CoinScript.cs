using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float UpForce;

    public float TimeToDelete;

    [SerializeField] int money;
    [SerializeField] TextMesh textMesh;
    [SerializeField] dongScript GM;
    [SerializeField] SpriteRenderer spr;
    [SerializeField] Sprite sprRef;

    private void Start()
    {
        GameObject GO = GameObject.FindGameObjectWithTag("Manager");
        GM = GO.GetComponent<dongScript>();
        money = GM.ddNormal + Random.Range(-5, 5);
        textMesh.text = "+" + "<color=#000000>" + money + "</color>" + "@";
        GM.score += money;

    }
    private void Update()
    {



        TimeToDelete -= Time.deltaTime;
        if(TimeToDelete < 0)
        {
            Destroy(gameObject);
        }


        gameObject.transform.position += new Vector3(0, UpForce, 0);
    }
}
