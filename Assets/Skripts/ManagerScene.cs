using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public YandexSDK sdk;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("carType"))
        {
            PlayerPrefs.SetInt("carType", 1);
        }

    }
    void Start()
    {
        sdk = YandexSDK.instance;
        sdk.onInterstitialShown += SDKNull;
        sdk.onInterstitialShowing += PausedForShow;
        sdk.onInterstitialFailed += SDKNull;
        AddShow();
    }
    void SDKNull(string s)
    {

    }
    void SDKNull()
    {
       Pause(false);
    }
    void PausedForShow()
    {
       Pause(true);
    }
    public void Pause(bool pause)
    {
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void PrefRegisterForMe()
    {
        for (int i = 3; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            PlayerPrefs.SetFloat("bestTime" + i, 23);
        }
        PlayerPrefs.SetInt("balance", 259);
    }
    /*public void CarManager(int type)
    {
        PlayerPrefs.SetInt("carType", type);
    }*/
    public void AddShow()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        sdk.ShowInterstitial();
#endif

    }
    public void PlayButton()
    {
        AddShow();
       for(int i =3;i < SceneManager.sceneCountInBuildSettings; i++)
        {
            if (PlayerPrefs.GetFloat("bestTime" + i) == 0|!PlayerPrefs.HasKey("bestTime" + i))
            {
                SceneManager.LoadScene(i);
                break;
            }
            SceneManager.LoadScene(i);
        }
    }
    public void BackButton()
    {//Proomo
     AddShow();
     //Proomo
        SceneManager.LoadScene(0);
        Debug.Log("Back");
    }
    public void SceneOpen(int index)
    {
        AddShow();
        SceneManager.LoadScene(index);
    }
    public void NextButton()
    {
        AddShow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void DeleteRecords()
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        //PlayerPrefs.DeleteKey("bestTime");
        /*for (int i =3;i< SceneManager.sceneCountInBuildSettings; i++)
        {
            PlayerPrefs.DeleteKey("bestTime" + i);
        }*/
        PlayerPrefs.DeleteAll();
    }

}
