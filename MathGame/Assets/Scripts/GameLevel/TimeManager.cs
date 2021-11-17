using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class TimeManager : MonoBehaviour
{
    bool timeCheck;
    public Text timetext;
    public int time = 30;
    [SerializeField]
    private GameObject finishPanel;
    RewardedAd rewardedAd;
    public GameObject rewardedButton;
    public bool rewardedvideo = false;
    private void Start()
    {
        timeCheck = true;
        StartCoroutine(Timer());
        Rewarded();
    }
    public IEnumerator Timer()
    {
        while (timeCheck)
        {
            yield return new WaitForSeconds(1f);
            timetext.text = time.ToString();
            time--;
            if (time <= 0)
            {
                timeCheck = false;
                timetext.text = "0";
                FinishGame();
            }
        }
    }
    public void FinishGame()
    {
        finishPanel.GetComponent<RectTransform>().localScale = Vector3.one;
    }
    public void Rewarded()
    {
        RequestConfiguration requestConfiguration = new RequestConfiguration.Builder()
        .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.True)
        .build();
        MobileAds.SetRequestConfiguration(requestConfiguration);
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);


        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        if (time == 0)
        {
            finishPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
            time += 10;
            timetext.text = time.ToString();
            timeCheck = true;
            StartCoroutine(Timer());
            rewardedButton.SetActive(false);
        }
    }
    public void OpenRewarded()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
}
