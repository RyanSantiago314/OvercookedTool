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

    public AudioSource frySound;
    public AudioSource ovenSound;
    public AudioSource stoveSound;

    public AudioClip stoveSizzle;
    public AudioClip fryerSizzle;
    public AudioClip ovenFan;
    public AudioClip smokeAlarm;
    public AudioClip ding;

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
            if (frySound.clip != smokeAlarm)
            {
                frySound.clip = smokeAlarm;
                frySound.loop = true;
                frySound.Play();
            }
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

            if (frySound.clip != ding)
            {
                frySound.Stop();
                frySound.clip = ding;
                frySound.Play();
                frySound.loop = false;
            }
        }

        if (OvenFire)
        {
            timeBarOven.color = Color.black;
            OvenButton.color = new Color32(100, 0, 0, 255);

            if (ovenSound.clip != smokeAlarm)
            {
                ovenSound.clip = smokeAlarm;
                ovenSound.loop = true;
                ovenSound.Play();
            }
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
            if (ovenSound.clip != ding)
            {
                ovenSound.Stop();
                ovenSound.clip = ding;
                ovenSound.Play();
                ovenSound.loop = false;
            }
        }

        if (StoveFire)
        {
            timeBarStove.color = Color.black;
            StoveButton.color = new Color32(100, 0, 0, 255);

            if (stoveSound.clip != smokeAlarm)
            {
                stoveSound.clip = smokeAlarm;
                stoveSound.loop = true;
                stoveSound.Play();
            }
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

            if (stoveSound.clip != ding)
            {
                stoveSound.Stop();
                stoveSound.clip = ding;
                stoveSound.Play();
                stoveSound.loop = false;
            }
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
                frySound.clip = fryerSizzle;
                frySound.Play();
                frySound.loop = true;
            }
            else if (FryFire)
            {
                FryerTimer -= 3;
                if (FryerTimer <= 0)
                {
                    FryerTimer = 0;
                    FryFire = false;
                    UsingFry = false;
                    frySound.Stop();
                    frySound.loop = false;
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
                ovenSound.clip = ovenFan;
                ovenSound.Play();
                ovenSound.loop = true;
            }
            else if (OvenFire)
            {
                OvenTimer -= 3;
                if (OvenTimer <= 0)
                {
                    OvenTimer = 0;
                    OvenFire = false;
                    UsingOven = false;
                    ovenSound.Stop();
                    ovenSound.loop = false;
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
                stoveSound.clip = stoveSizzle;
                stoveSound.Play();
                stoveSound.loop = true;
            }
            else if (StoveFire)
            {
                StoveTimer -= 3;
                if (StoveTimer <= 0)
                {
                    StoveTimer = 0;
                    StoveFire = false;
                    UsingStove = false;
                    stoveSound.Stop();
                    stoveSound.loop = false;
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
            frySound.Stop();
        }
        else if (station == "Oven" && !OvenFire && UsingOven)
        {
            UsingOven = false;
            OvenTimer = 0;
            ovenSound.Stop();
        }
        else if (!StoveFire && UsingStove)
        {
            UsingStove = false;
            StoveTimer = 0;
            stoveSound.Stop();
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
