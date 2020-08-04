using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDMoneyScript : MonoBehaviour
{
    public Animator ani;

    public int finalDDMoney;
    public int hamsterLvMoney;
    public bool destroyActive;
    public bool once;

    public int goldenBonus;

    public GameObject coinTextOB;
    [SerializeField] BoxCollider2D box;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TextMesh text;
    private void Start()
    {

        if(gameObject.tag == "DD")
        {
            goldenBonus = 1;
        }
        else
        {
            goldenBonus = 2;
        }
        finalDDMoney = hamsterLvMoney * goldenBonus;
        text.text = "+" + "<color=#000000>" + finalDDMoney + "</color>" + "@";

    }
}
