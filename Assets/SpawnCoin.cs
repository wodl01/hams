using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    
    [SerializeField] int money;
    [SerializeField] TextMesh textMesh;
    [SerializeField] dongScript GM;
    [SerializeField] SpriteRenderer spr;
    [SerializeField] Sprite sprRef;

    private void Start()
    {

        GameObject GO = GameObject.FindGameObjectWithTag("Manager");
        GM = GO.GetComponent<dongScript>();
        int randomNumber = Random.Range(0, 100);

        if (randomNumber < GM.ddNormalRate)
        {
            // 평범한똥
            money = GM.ddNormal + Random.Range(-5, 5);
        }
        else
        {
            // 황금똥
            money = GM.ddGold + Random.Range(-10,10);
            spr.sprite = sprRef;
        }

        textMesh.text = "+" + "< color =#000000>" + money + "</color>" + "@";
        GM.score += money;
    }
}
