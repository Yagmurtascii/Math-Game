using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class FinishManager : MonoBehaviour
{
    public void StartANewGame()
    {
        SceneManager.LoadScene("GameScene");
        
    }
    public void TurnBackHoma()
    {
        SceneManager.LoadScene("MenuScene");
    }
  

}
