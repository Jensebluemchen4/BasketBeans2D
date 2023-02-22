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



    public void Update()
    {
        if (score.scoreCounter.ToString() != num.text && stageBasket == false)
        {
            if (score.scoreCounter > 99)
                num.text = score.scoreCounter.ToString();
            else if (score.scoreCounter > 9)
                num.text = "0" + score.scoreCounter.ToString();
            else if (score.scoreCounter <= 9)
                num.text = "00" + score.scoreCounter.ToString();
            else if (score.scoreCounter == 0)
                num.text = "000" + score.scoreCounter.ToString();

            if (score.scoreCounter >= 1000)
                score.scoreCounter = 0;
        }
        else if (score.scoreCounter.ToString() != num.text && stageBasket == true)
        {
            if (destroy == true)
                toDestroy.SetActive(true);
            else
                toBuild.SetActive(false);

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
