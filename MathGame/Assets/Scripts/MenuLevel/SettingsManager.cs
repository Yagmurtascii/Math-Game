using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject SettingPanel, Home;
    public GameObject TurnOn;
    public void SettingButton()
    {
        SettingPanel.SetActive(true);
    }
    public void BackHome()
    {
        SettingPanel.SetActive(false);
    }
 
}



