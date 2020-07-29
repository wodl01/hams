using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBowlScript : MonoBehaviour
{
    public GameObject water;
    [SerializeField] SpriteRenderer bringWaterSprite;
    [SerializeField] Sprite water4;
    [SerializeField] Sprite water3;
    [SerializeField] Sprite water2;
    [SerializeField] Sprite water1;
    [SerializeField] Sprite waterNone;
    public GameObject Sign;

    public bool isFull;

    public int waterGauge = 4;

    private void Start()
    {
        bringWaterSprite = water.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (waterGauge == 4)
        {
            bringWaterSprite.sprite = water4;
            Sign.SetActive(false);
        }
        if (waterGauge == 3)
        {
            bringWaterSprite.sprite = water3;
            Sign.SetActive(false);
        }
        if (waterGauge == 2)
        {
            bringWaterSprite.sprite = water2;
            Sign.SetActive(false);
        }
        if (waterGauge == 1)
        {
            bringWaterSprite.sprite = water1;
            Sign.SetActive(false);
        }
        if (waterGauge == 0)
        {
            bringWaterSprite.sprite = waterNone;
            Sign.SetActive(true);
        }
    }
}
