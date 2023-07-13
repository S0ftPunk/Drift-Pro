using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsRegister : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("prefsRegistred"))
        {
            PlayerPrefs.SetInt("1", 1);
            PlayerPrefs.SetInt("balance", 0);
            //LevelPrefsFill();
            PlayerPrefs.SetInt("prefsRegistred", 1);
        }
    }
    private void LevelPrefsFill()
    {
        for(int i = 3; i <= 22; i++)
        {
            PlayerPrefs.SetFloat("bestTime" + i,0);
        }
    }
    //Proomo
    public void PrefsFull()
    {
        for (int i = 3; i <= 22; i++)
        {
            PlayerPrefs.SetFloat("bestTime" + i, 20);
        }
        PlayerPrefs.SetInt("balance", 500);
    }
}
