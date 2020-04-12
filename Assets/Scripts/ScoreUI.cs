using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private GameObject scoreUI;
    private Text score;
    private void Awake()
    {
        scoreUI = gameObject;
        score = GetComponent<Text>();
    }




    // Update is called once per frame
    void Update()
    {//Update game score or highscore
        if (scoreUI.tag == "Score")
        {
            score.text = $"Score: { Score.instance.score.ToString()}";
        }
        if (scoreUI.tag == "HighScore")
        {
            score.text = $"High Score: { Score.instance.GetHighScore().ToString()}";
        }
        if (scoreUI.tag == "HighWinScore")
        {
            string text = Score.instance.isHighScore ? "Winning" : "High";
            score.text = $"{text} Score: { Score.instance.GetHighScore().ToString()}";
        }
    }

}
