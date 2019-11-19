using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationTimers : MonoBehaviour
{
    public Image timeBarFry;
    public Image timeBarOven;
    public Image timeBar;

    int OvenTime = 25;
    int FryerTime = 15;
    int StoveTime = 20;

    float FryerTimer = 0;
    float OvenTimer = 0;
    float StoveTimer = 0;

    bool UsingFry = false;
    bool UsingOven = false;
    bool UsingStove = false;

    bool FryFire = false;
    bool OvenFire = false;
    bool StoveFire = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UsingFry)
            FryerTimer += Time.deltaTime;
        if(UsingStove)
            StoveTimer += Time.deltaTime;
        if(UsingOven)
            OvenTimer += Time.deltaTime;

        if(FryerTimer >= FryerTime + 5)
            FryFire = true;
        if(OvenTimer >= OvenTime + 5)
            OvenFire = true;
        if(StoveTimer >= StoveTime + 5)
            StoveFire = true;
    }

    public void StationTime(string station)
    {
        if (station == "DeepFry")
        {
            if(!UsingFry)
            {
                UsingFry = true;
            }
            else if (FryFire)
            {
                FryerTimer -= 5;
                if (FryerTimer <= 0)
                    FryFire = false;
            }
            else if (UsingFry && FryerTimer >= FryerTime)
            {
                UsingFry = false;
                FryerTimer = 0;
            }
        }
        else if (station == "Oven")
        {
            if(!UsingOven)
            {
                UsingOven = true;
            }
            else if (OvenFire)
            {
                OvenTimer -= 5;
                if (OvenTimer <= 0)
                    OvenFire = false;
            }
            else if (UsingOven && OvenTimer >= OvenTime)
            {
                UsingOven = false;
                OvenTimer = 0;
            }
        }
        else
        {
            if(!UsingStove)
            {
                UsingStove = true;
            }
            else if (StoveFire)
            {
                StoveTimer -= 5;
                if (StoveTimer <= 0)
                    StoveFire = false;
            }
            else if (UsingStove && StoveTimer >= StoveTime)
            {
                UsingStove = false;
                StoveTimer = 0;
            }
        }
    }
}
