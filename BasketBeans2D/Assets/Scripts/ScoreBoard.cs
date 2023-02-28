using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text num;
    public Basket score;
    public bool stageBasket = false;
    public bool destroy;
    public GameObject toBuild;
    public GameObject toDestroy;
    [SerializeField] private int toScore;


    private void Awake()
    {

        if (stageBasket == true)
        {
            score.scoreCounter = 0;
            if (destroy == true)
                toDestroy.SetActive(true);
            else
                toBuild.SetActive(false);
        }
    }


    public void Update()
    {
        if (score.scoreCounter.ToString() != num.text && stageBasket == false)
        {
            if (Basket.totalScoreCounter > 99)
                num.text = Basket.totalScoreCounter.ToString();
            else if (Basket.totalScoreCounter > 9)
                num.text = "0" + Basket.totalScoreCounter.ToString();
            else if (Basket.totalScoreCounter <= 9)
                num.text = "00" + Basket.totalScoreCounter.ToString();
            else if (Basket.totalScoreCounter == 0)
                num.text = "000" + Basket.totalScoreCounter.ToString();

            if (score.scoreCounter >= 1000)
                score.scoreCounter = 0;
        }
        else if (score.scoreCounter.ToString() != num.text && stageBasket == true)
        {
            if (score.scoreCounter <= 0)
                num.text = "0/" + toScore.ToString();
            else if (score.scoreCounter > 0 && score.scoreCounter <= toScore)
                num.text = score.scoreCounter.ToString() + "/" + toScore.ToString();

            if (score.scoreCounter >= toScore)
            {
                if (destroy == true)
                    toDestroy.SetActive(false);
                else
                    toBuild.SetActive(true);
                num.color = new Color(0, 100, 0);
                score.scoreCounter = toScore;
            }
        }
    }
}
