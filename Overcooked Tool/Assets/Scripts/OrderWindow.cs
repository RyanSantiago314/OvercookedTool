using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderWindow : MonoBehaviour
{
    public Image Order1;
    public Image Order2;
    public Image Order3;
    public Image timeBar1;
    public Image timeBar2;
    public Image timeBar3;
    public Text scoreText;
    public Text pauseButtonText;
    public Text timeText;

    public Sprite burger;
    public Sprite cheeseBurger;
    public Sprite cheesePizza;
    public Sprite meatPizza;
    public Sprite fishPizza;
    public Sprite fishNChips;
    public Sprite fries;
    public Sprite vegWich;
    public Sprite grilledCheese;
    public Sprite salad;
    public Sprite gardenSalad;
    public Sprite soup;

    float gameTime = 601;
    float gameTimer;
    int gameMinutes;
    int gameSeconds;
    int gameScore;

    public bool playing = false;
    bool noCards = false;

    float OrderTimer1 = 120;
    float OrderTimer2 = 120;
    float OrderTimer3 = 120;

    int currentOrder1;
    int currentOrder2;
    int currentOrder3;

    float MaxOrderTime = 120;
    int CardCount = 3;
    int cardCheck = 0;

    int[] cardCounts = new int[12];

    int[] pointValues = new int[12];


    public enum orderCards //never used just for reference
    {
        BUR = 0,
        CHB = 1,
        CHP = 2,
        MEP = 3,
        FIP = 4,
        FIC = 5,
        FRI = 6,
        VEG = 7,
        GRC = 8,
        SAL = 9,
        GAS = 10,
        SUP = 11
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeDeck();

        for(int i = 0; i < pointValues.Length; i++)
        {
            if (i == (int)orderCards.SAL)
                pointValues[i] = 5;
            else if (i == (int)orderCards.CHB || i == (int)orderCards.GRC || i == (int)orderCards.FRI || i == (int)orderCards.GAS || i == (int)orderCards.SUP)
                pointValues[i] = 10;
            else if (i == (int)orderCards.BUR || i == (int)orderCards.VEG)
                pointValues[i] = 15;
            else if (i == (int)orderCards.FIC || i == (int)orderCards.CHP)
                pointValues[i] = 20;
            else
                pointValues[i] = 25;

        }
        gameTimer = gameTime;

        int rand1 = Random.Range(0, 12);
        int rand2 = Random.Range(0, 12);
        int rand3 = Random.Range(0, 12);
        ChangeOrder(Order1, rand1);
        ChangeOrder(Order2, rand2);
        ChangeOrder(Order3, rand3);
        currentOrder1 = rand1;
        currentOrder2 = rand2;
        currentOrder3 = rand3;

        GameReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSeconds > 9)
            timeText.text = gameMinutes + ":" + gameSeconds;
        else
            timeText.text = gameMinutes + ":0" + gameSeconds;

        if (playing)
        {
            int rand1 = Random.Range(0,12);
            int rand2 = Random.Range(0,12);
            int rand3 = Random.Range(0,12);

            timeBar1.color = Color.Lerp(Color.red, Color.green, timeBar1.fillAmount);
            timeBar2.color = Color.Lerp(Color.red, Color.green, timeBar2.fillAmount);
            timeBar3.color = Color.Lerp(Color.red, Color.green, timeBar3.fillAmount);

            if(OrderTimer1 <= 0)
            {
                while(cardCounts[rand1] == 0)
                {
                    rand1++;
                    cardCheck++;
                    if(rand1 > 11)
                        rand1 = 0;
                    if(cardCheck >= 12)
                        MakeDeck();
                }
                ChangeOrder(Order1, rand1);
                OrderTimer1 = MaxOrderTime;
                gameScore -= 10;
            }
            if(OrderTimer2 <= 0)
            {
                while(cardCounts[rand2] == 0)
                {
                    rand2++;
                    cardCheck++;
                    if(rand2 > 11)
                        rand2 = 0;
                    if(cardCheck >= 12)
                        MakeDeck();
                }
                ChangeOrder(Order2, rand2);
                OrderTimer2 = MaxOrderTime;
                gameScore -= 10;
            }
            if(OrderTimer3 <= 0)
            {
                while(cardCounts[rand3] == 0)
                {
                    rand3++;
                    cardCheck++;
                    if(rand3 > 11)
                        rand3 = 0;
                    if(cardCheck >= 12)
                        MakeDeck();
                }
                ChangeOrder(Order3, rand3);
                OrderTimer3 = MaxOrderTime;
                gameScore -= 10;
            }

            OrderTimer1 -= Time.deltaTime;
            OrderTimer2 -= Time.deltaTime;
            OrderTimer3 -= Time.deltaTime;

            pauseButtonText.text = "Pause";
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0)
                playing = false;

            gameMinutes = (int)gameTimer / 60;
            gameSeconds = (int)gameTimer % 60;
        }
        else
        {
            pauseButtonText.text = "Play";
        }

        scoreText.text = gameScore.ToString();

        timeBar1.fillAmount = OrderTimer1/MaxOrderTime;
        timeBar2.fillAmount = OrderTimer2/MaxOrderTime;
        timeBar3.fillAmount = OrderTimer3/MaxOrderTime;
        
    }

    public void GameStartPause()
    {
        if (playing)
            playing = false;
        else
            playing = true;
    }

    public void GameReset()
    {
        playing = false;
        gameScore = 0;
        OrderTimer1 = MaxOrderTime;
        OrderTimer2 = MaxOrderTime;
        OrderTimer3 = MaxOrderTime;
        gameTimer = gameTime;
        ChangeOrder(Order1, Random.Range(0, 12));
        ChangeOrder(Order2, Random.Range(0, 12));
        ChangeOrder(Order3, Random.Range(0, 12));
    }

    public void ClearOrder1()
    {
        if (playing)
        {
            int rand = Random.Range(0, 12);
            while(cardCounts[rand] == 0)
            {
                rand++;
                cardCheck++;

                if(rand > 11)
                    rand = 0;
                if(cardCheck >= 12)
                    MakeDeck();
            }

            gameScore += pointValues[currentOrder1];
            ChangeOrder(Order1, rand);
            currentOrder1 = rand;
            OrderTimer1 = MaxOrderTime;
        }
    }
    public void ClearOrder2()
    {
        if (playing)
        {
            int rand = Random.Range(0, 12);
            while(cardCounts[rand] == 0)
            {
                rand++;
                cardCheck++;
                if(rand > 11)
                    rand = 0;
                if(cardCheck >= 12)
                    MakeDeck();
            }

            gameScore += pointValues[currentOrder2];
            ChangeOrder(Order2, rand);
            currentOrder2 = rand;
            OrderTimer2 = MaxOrderTime;
        }
    }
    public void ClearOrder3()
    {
        if (playing)
        {
            int rand = Random.Range(0, 12);
            while(cardCounts[rand] == 0)
            {
                rand++;
                cardCheck++;
                if(rand > 11)
                    rand = 0;
                if(cardCheck >= 12)
                    MakeDeck();
            }

            gameScore += pointValues[currentOrder3];
            ChangeOrder(Order3, rand);
            currentOrder3 = rand;
            OrderTimer3 = MaxOrderTime;
        }
    }

    void ChangeOrder(Image Order, int num)
    {
        cardCounts[num]--;
        cardCheck = 0;
        switch(num)
        {
            case 0:
            {
                Order.sprite = burger;
                break;
            }
            case 1:
            {
                Order.sprite = cheeseBurger;
                break;
            }
            case 2:
            {
                Order.sprite = cheesePizza;
                break;
            }
            case 3:
            {
                Order.sprite = meatPizza;
                break;
            }
            case 4:
            {
                Order.sprite = fishPizza;
                break;
            }
            case 5:
            {
                Order.sprite = fishNChips;
                break;
            }
            case 6:
            {
                Order.sprite = fries;
                break;
            }
            case 7:
            {
                Order.sprite = vegWich;
                break;
            }
            case 8:
            {
                Order.sprite = grilledCheese;
                break;
            }
            case 9:
            {
                Order.sprite = salad;
                break;
            }
            case 10:
            {
                Order.sprite = gardenSalad;
                break;
            }
            case 11:
            {
                Order.sprite = soup;
                break;
            }
            default:
            {
                break;
            }
        }
    }

    void MakeDeck()
    {
        Debug.Log("Replenishing deck");
        for(int i = 0; i < cardCounts.Length; i++)
        {
            if (i >= 2 && i <= 4)
                cardCounts[i] = 2;
            else
                cardCounts[i] = CardCount;
        }
    }
}
