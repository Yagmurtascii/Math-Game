using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    public void PauseButton()
    {
        PausePanel.SetActive(true);
    }
}
