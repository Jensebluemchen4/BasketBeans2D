using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int totalScoreCounter;

    public GameData ()
    {
        totalScoreCounter = Basket.totalScoreCounter;
    }
}
