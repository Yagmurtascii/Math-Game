using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    [SerializeField]
    GameObject startbutton,exitbutton,gametext;
    void Start()
    {
        FadeOut();
    }
    void FadeOut()
    {
        startbutton.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        exitbutton.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
        gametext.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
