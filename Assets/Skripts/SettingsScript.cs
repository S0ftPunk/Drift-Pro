using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Image image;
    public Sprite of, on;
    private string status;
    public AudioSource audio;
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicStatus"))
        {
            status = PlayerPrefs.GetString("MusicStatus");
            if(status == "off")
            {
                image.sprite = of;
                audio.volume = 0;
            }
            else
            {
                image.sprite = on;
                audio.volume = 0.6f;
            }
        }
        else
        {
            status = "on";
        }
    }

    public void musicManager()
    {
        audio = FindObjectOfType<AudioSource>();
        if (status == "on")
        {
            status = "off";
            PlayerPrefs.SetString("MusicStatus", status);
            image.sprite = of;
            audio.volume = 0;
        }
        else
        {
            status = "on";
            PlayerPrefs.SetString("MusicStatus", status);
            image.sprite = on;
            audio.volume = 0.6f;
        }
    }
}
