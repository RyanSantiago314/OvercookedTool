using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationTimers : MonoBehaviour
{
    public GameObject Fryer;
    public GameObject Oven;
    public GameObject Stove;

    public Image FryButton;
    public Image OvenButton;
    public Image StoveButton;

    public Image timeBarFry;
    public Image timeBarOven;
    public Image timeBarStove;

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
        if (UsingFry)
        {
            Fryer.SetActive(true);
            FryerTimer += Time.deltaTime;
        }
        else
        {
            Fryer.SetActive(false);
        }

        if(UsingStove)
        {
            Stove.SetActive(true);
            StoveTimer += Time.deltaTime;
        }
        else
        {
            Stove.SetActive(false);
        }

        if (UsingOven)
        {
            Oven.SetActive(true);
            OvenTimer += Time.deltaTime;
        }
        else
        {
            Oven.SetActive(false);
        }

        if (FryFire)
        {
            timeBarFry.color = Color.black;
            FryButton.color = new Color32(100, 0, 0, 255);
        }
        else if (FryerTimer <= FryerTime)
        {
            timeBarFry.color = new Color32(40, 128, 40, 255);
            FryButton.color = new Color32(69, 207, 176, 255);
        }
        else if (FryerTimer > FryerTime)
        {
            timeBarFry.color = Color.Lerp(new Color32(40, 128, 40, 255), new Color32(10, 0, 0, 255), (FryerTimer - FryerTime) / 5);
            FryButton.color = Color.Lerp(new Color32(69, 207, 176, 255), new Color32(100, 0, 0, 255), (FryerTimer - FryerTime) / 5);
        }

        if (OvenFire)
        {
            timeBarOven.color = Color.black;
            OvenButton.color = new Color32(100, 0, 0, 255);
        }
        else if (OvenTimer <= OvenTime)
        {
            timeBarOven.color = new Color32(40, 128, 40, 255);
            OvenButton.color = new Color32(69, 207, 176, 255);
        }
        else if (OvenTimer > OvenTime)
        {
            timeBarOven.color = Color.Lerp(new Color32(40, 128, 40, 255), new Color32(10, 0, 0, 255), (OvenTimer - OvenTime) / 5);
            OvenButton.color = Color.Lerp(new Color32(69, 207, 176, 255), new Color32(100, 0, 0, 255), (OvenTimer - OvenTime) / 5);
        }

        if (StoveFire)
        {
            timeBarStove.color = Color.black;
            StoveButton.color = new Color32(100, 0, 0, 255);
        }
        else if (StoveTimer <= StoveTime)
        {
            timeBarStove.color = new Color32(40, 128, 40, 255);
            StoveButton.color = new Color32(69, 207, 176, 255);
        }
        else if (StoveTimer > StoveTime)
        {
            timeBarStove.color = Color.Lerp(new Color32(40, 128, 40, 255), new Color32(10, 0, 0, 255), (StoveTimer - StoveTime) / 5);
            StoveButton.color = Color.Lerp(new Color32(69, 207, 176, 255), new Color32(100, 0, 0, 255), (StoveTimer - StoveTime) / 5);
        }

        timeBarFry.fillAmount = FryerTimer / FryerTime;
        timeBarOven.fillAmount = OvenTimer / OvenTime;
        timeBarStove.fillAmount = StoveTimer / StoveTime;


        if (FryerTimer >= FryerTime + 5)
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
                FryerTimer -= 3;
                if (FryerTimer <= 0)
                {
                    FryerTimer = 0;
                    FryFire = false;
                    UsingFry = false;
                }
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
                OvenTimer -= 3;
                if (OvenTimer <= 0)
                {
                    OvenTimer = 0;
                    OvenFire = false;
                    UsingOven = false;
                }
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
                StoveTimer -= 3;
                if (StoveTimer <= 0)
                {
                    StoveTimer = 0;
                    StoveFire = false;
                    UsingStove = false;
                }
            }
            else if (UsingStove && StoveTimer >= StoveTime)
            {
                UsingStove = false;
                StoveTimer = 0;
            }
        }
    }

    public void StationShutoff(string station)
    {
        if (station == "DeepFry" && !FryFire && UsingFry)
        {
            UsingFry = false;
            FryerTimer = 0;
        }
        else if (station == "Oven" && !OvenFire && UsingOven)
        {
            UsingOven = false;
            OvenTimer = 0;
        }
        else if (!StoveFire && UsingStove)
        {
            UsingStove = false;
            StoveTimer = 0;
        }
    }

    public void Reset()
    {
        OvenTimer = 0;
        StoveTimer = 0;
        FryerTimer = 0;
        UsingFry = false;
        UsingOven = false;
        UsingStove = false;
    }
}
