using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score { get; private set; }
    public bool isHighScore { get; private set; }


    void Awake()
    {//Singleton Pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        score = 0;
        isHighScore = false;
        StartCoroutine("AddBonusScore", 5);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void SaveHighScore()
    {//If score is a high score, save it
        if (score > GetHighScore()) {
            PlayerPrefs.SetInt("HighScore", score);
            isHighScore = true;
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    IEnumerator AddBonusScore(int bonus)
    {
        while (true)
        {
            yield return new WaitForSeconds(bonus);
            AddScore(bonus);
        }
    }

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            StopCoroutine("AddBonusScore");
        }
    }

}
