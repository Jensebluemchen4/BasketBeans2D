using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int scoreCounter;

    public GameData (Basket basket)
    {
        scoreCounter = basket.scoreCounter;
    }
}
