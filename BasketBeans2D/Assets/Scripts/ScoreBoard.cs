using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text num;
    public ActivateBasket score;

    public void Update()
    {
        if (score.scoreCounter.ToString() != num.text)
        {
            if (score.scoreCounter > 99)
                num.text = score.scoreCounter.ToString();
            else if (score.scoreCounter > 9)
                num.text = "0" + score.scoreCounter.ToString();
            else if (score.scoreCounter <= 9)
                num.text = "00" + score.scoreCounter.ToString();
            else if (score.scoreCounter == 0)
                num.text = "000" + score.scoreCounter.ToString();
        }

        if (score.scoreCounter >= 1000)
            score.scoreCounter = 0;
    }
}
