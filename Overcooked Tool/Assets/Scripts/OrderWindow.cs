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

    float gameTime = 600;
    float gameTimer;
    int gameMinutes;
    int gameSeconds;
    int gameScore;

    bool playing = true;
    bool noCards = false;

    float OrderTimer1 = 120;
    float OrderTimer2 = 120;
    float OrderTimer3 = 120;

    int currentOrder1;
    int currentOrder2;
    int currentOrder3;

    float MaxOrderTime = 120;
    int CardCount = 3;

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
        for(int i = 0; i < cardCounts.Length; i++)
        {
            cardCounts[i] = CardCount;
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
        ChangeOrder(Order1, Random.Range(0, 12), currentOrder1);
        ChangeOrder(Order2, Random.Range(0, 12), currentOrder2);
        ChangeOrder(Order3, Random.Range(0, 12), currentOrder3);
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            int rand1 = Random.Range(0,12);
            int rand2 = Random.Range(0,12);
            int rand3 = Random.Range(0,12);

            timeBar1.fillAmount = OrderTimer1/MaxOrderTime;
            timeBar2.fillAmount = OrderTimer2/MaxOrderTime;
            timeBar3.fillAmount = OrderTimer3/MaxOrderTime;

            timeBar1.color = Color.Lerp(Color.red, Color.green, timeBar1.fillAmount);
            timeBar2.color = Color.Lerp(Color.red, Color.green, timeBar2.fillAmount);
            timeBar3.color = Color.Lerp(Color.red, Color.green, timeBar3.fillAmount);

            if(OrderTimer1 <= 0)
            {
                ChangeOrder(Order1, rand1, currentOrder1);
                OrderTimer1 = MaxOrderTime;
                gameScore -= 10;
            }
            if(OrderTimer2 <= 0)
            {
                ChangeOrder(Order2, rand2, currentOrder2);
                OrderTimer2 = MaxOrderTime;
                gameScore -= 10;
            }
            if(OrderTimer3 <= 0)
            {
                ChangeOrder(Order3, rand3, currentOrder3);
                OrderTimer3 = MaxOrderTime;
                gameScore -= 10;
            }

            OrderTimer1 -= Time.deltaTime;
            OrderTimer2 -= Time.deltaTime;
            OrderTimer3 -= Time.deltaTime;

            if (noCards)
            {
                for (int i = 0; i < cardCounts.Length; i++)
                {
                    cardCounts[i] = CardCount;
                }
                noCards = false;
            }
            pauseButtonText.text = "Pause";
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0)
                playing = false;
        }
        else
        {
            pauseButtonText.text = "Resume";
        }

        scoreText.text = gameScore.ToString();

        
        
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
        gameScore = 0;
        OrderTimer1 = MaxOrderTime;
        OrderTimer2 = MaxOrderTime;
        OrderTimer3 = MaxOrderTime;
        gameTimer = gameTime;
        ChangeOrder(Order1, Random.Range(0, 12), currentOrder1);
        ChangeOrder(Order2, Random.Range(0, 12), currentOrder2);
        ChangeOrder(Order3, Random.Range(0, 12), currentOrder3);
    }

    public void ClearOrder1()
    {
        if (playing)
        {
            gameScore += pointValues[currentOrder1];
            ChangeOrder(Order1, Random.Range(0, 12), currentOrder1);
            OrderTimer1 = MaxOrderTime;
        }
    }
    public void ClearOrder2()
    {
        if (playing)
        {
            gameScore += pointValues[currentOrder2];
            ChangeOrder(Order2, Random.Range(0, 12), currentOrder2);
            OrderTimer2 = MaxOrderTime;
        }
    }
    public void ClearOrder3()
    {
        if (playing)
        {
            gameScore += pointValues[currentOrder3];
            ChangeOrder(Order3, Random.Range(0, 12), currentOrder3);
            OrderTimer3 = MaxOrderTime;
        }
    }

    void ChangeOrder(Image Order, int num, int currentOrder)
    {
        switch(num)
        {
            case 0:
            {
                if(cardCounts[0] > 0)
                {
                    Order.sprite = burger;
                    cardCounts[0]--;
                    currentOrder = 0;
                }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 1:
            {
                if(cardCounts[1] > 0)
                {
                    Order.sprite = cheeseBurger;
                    cardCounts[1]--;
                    currentOrder = 1;
                }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 2:
            {
                if(cardCounts[2] > 0)
                {
                    Order.sprite = cheesePizza;
                    cardCounts[2]--;
                        currentOrder = 2;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 3:
            {
                if(cardCounts[3] > 0)
                {
                    Order.sprite = meatPizza;
                    cardCounts[3]--;
                        currentOrder = 3;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 4:
            {
                if(cardCounts[4] > 0)
                {
                    Order.sprite = fishPizza;
                    cardCounts[4]--;
                        currentOrder = 4;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 5:
            {
                if(cardCounts[5] > 0)
                {
                    Order.sprite = fishNChips;
                    cardCounts[5]--;
                        currentOrder = 5;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 6:
            {
                if(cardCounts[6] > 0)
                {
                    Order.sprite = fries;
                    cardCounts[6]--;
                        currentOrder = 6;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 7:
            {
                if(cardCounts[7] > 0)
                {
                    Order.sprite = vegWich;
                    cardCounts[7]--;
                        currentOrder = 7;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 8:
            {
                if(cardCounts[8] > 0)
                {
                    Order.sprite = grilledCheese;
                    cardCounts[8]--;
                        currentOrder = 8;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 9:
            {
                if(cardCounts[9] > 0)
                {
                    Order.sprite = salad;
                    cardCounts[9]--;
                        currentOrder = 9;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 10:
            {
                if(cardCounts[10] > 0)
                {
                    Order.sprite = gardenSalad;
                    cardCounts[10]--;
                        currentOrder = 10;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            case 11:
            {
                if(cardCounts[11] > 0)
                {
                    Order.sprite = soup;
                    cardCounts[11]--;
                        currentOrder = 11;
                    }
                else
                {
                    ChangeOrder(Order, ++num, currentOrder);
                }
                break;
            }
            default:
            {
                noCards = true;
                Debug.Log("Replenishing deck");
                break;
            }
        }
    }
}
