using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBowlScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer bringWaterSprite;
    [SerializeField] Sprite water4;
    [SerializeField] Sprite water3;
    [SerializeField] Sprite water2;
    [SerializeField] Sprite water1;
    [SerializeField] Sprite waterNone;
    public GameObject sign;


    public int waterGauge = 4;

    private void Start()
    {

    }
    void Update()
    {
        if (waterGauge == 4)
        {
            bringWaterSprite.sprite = water4;
            sign.SetActive(false);
        }
        if (waterGauge == 3)
        {
            bringWaterSprite.sprite = water3;
            sign.SetActive(false);
        }
        if (waterGauge == 2)
        {
            bringWaterSprite.sprite = water2;
            sign.SetActive(false);
        }
        if (waterGauge == 1)
        {
            bringWaterSprite.sprite = water1;
            sign.SetActive(false);
        }
        if (waterGauge == 0)
        {
            bringWaterSprite.sprite = waterNone;
            sign.SetActive(true);
        }
    }
}
