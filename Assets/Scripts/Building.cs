using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool spendWater = false;

    public int cost;
    public int electricityCost;
    public int goldSpend;

    public int goldIncrease;
    public int electricityIncrease;
    public int airIncrease;

    public float timeBtwIncreases;
    private float nextIncreaseTime;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBtwIncreases;
            if(gm.electricity > electricityCost)
            {
                gm.gold += goldIncrease;
            }
            if(gm.electricity > electricityCost && gm.gold > goldIncrease)
            {
                if(gm.air <= 100)
                {
                    gm.air += airIncrease;
                }

            }
            if(gm.electricity != 0)
            {
                gm.electricity += electricityIncrease - electricityCost;
            }
            if(electricityIncrease > 0)
            {
                gm.electricity += electricityIncrease;
            }
            if(spendWater)
            {
                if(gm.gold != 0)
                {
                    gm.gold -= goldSpend;
                }
            }
        }
    }
}
