using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderWindow : MonoBehaviour
{
    int[] orderCards = new int[12];

    int[] pointValues = new int[12];

    public enum orderCards
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
        for(int = 0; i < orderCards.length; i++)
        {
            orderCards[i] = GameDataBase.CardCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
