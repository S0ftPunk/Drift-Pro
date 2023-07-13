using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject audio;
    public SettingsScript settings;
    private bool IsObjectInDontDestroyOnLoad(GameObject obj)
    {
        Object[] objects = Object.FindObjectsOfType(obj.GetType());
        foreach (Object foundObj in objects)
        {
            if (foundObj == obj)
            {
                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        GameObject yourObject = GameObject.Find("AudioSource");
        
        if(FindObjectOfType<AudioSource>()==null)
        {

            DontDestroyOnLoad(audio);
            audio.SetActive(true);
            settings.audio = audio.GetComponent<AudioSource>();
        }
    }
}
