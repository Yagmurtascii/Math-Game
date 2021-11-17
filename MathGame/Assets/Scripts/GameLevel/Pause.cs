using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    public void ContinueGame()
    {
        PausePanel.SetActive(false);

    }
    public void TurnBackHome()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void StartANewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
