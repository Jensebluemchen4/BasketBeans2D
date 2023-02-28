using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    [SerializeField] public Rigidbody2D ball;
    public int scoreCounter;
    public static int totalScoreCounter;
    private bool hitFromTop;

    private void Awake()
    {
        ball.GetComponent<GameObject>();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            LoadScore();
        }
    }

    public void SaveScore()
    {
        SaveLoadSystem.SaveData();
    }

    public void LoadScore()
    {
        GameData data = SaveLoadSystem.LoadData();
        totalScoreCounter = data.totalScoreCounter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ball.velocity.y < 0)
        {
            hitFromTop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ball.velocity.y < 0 && hitFromTop == true)
        {
            scoreCounter++;
            totalScoreCounter++;
            SaveScore();
        }
        hitFromTop = false;
    }
}
