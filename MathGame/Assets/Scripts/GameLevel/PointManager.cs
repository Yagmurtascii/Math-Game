using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using System;

public class PointManager : MonoBehaviour
{
    public int score, highscore;
    private int accrual = 7;//artýþ miktarý
    int decrease = 3;
 
    [SerializeField]
    Text totaltext, highcsoretext,highscorepoint, scorepoint;

    void Start()
    {
        if (PlayerPrefs.HasKey("Scores"))
        {
            highscore = PlayerPrefs.GetInt("Scores", 0);
            highcsoretext.text = highscore.ToString();
        }
    }
    public void TotalIncrease()
    {
        score += accrual;
        totaltext.text = score.ToString();
        UpdateHighScore();
    }
    public void DecreaseTotal()
    {
        score -= decrease;
        totaltext.text = score.ToString();
        UpdateHighScore();
    }
    public void UpdateHighScore()
    {
        scorepoint.text = score.ToString();
        highscorepoint.text = highscore.ToString();
        if (score > highscore)
        {
            highscore = score;
            highcsoretext.text = highscore.ToString();
            PlayerPrefs.SetInt("Scores", highscore);
            PlayerPrefs.Save();
        }
    }
    public void ResetScore()
    {
        score = 0;
    }
    public void ResetHighScore()
    {
        highscore = 0;
    }
  
}



    




