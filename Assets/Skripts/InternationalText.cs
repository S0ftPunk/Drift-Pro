using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternationalText : MonoBehaviour
{
    [SerializeField] GameObject _en;
    [SerializeField] GameObject _ru;

    [SerializeField] LevelChanger text;

    private void Start()
    {
        if (Language.Instance.CurrentLang == "en")
        {
            _en.SetActive(true);
            _ru.SetActive(false);
            if (text != null)
            {
                text.levelForINternational = "Level ";
                text.playButton = _en.GetComponent<Button>();
            }
            
        }
        else if (Language.Instance.CurrentLang == "ru")
        {
            _en.SetActive(false);
            _ru.SetActive(true);
            if (text != null)
            {
                text.levelForINternational = "Уровень ";
                text.playButton = _ru.GetComponent<Button>();
            }
        }
        else
        {
            _en.SetActive(true);
            _ru.SetActive(false);
            if (text != null)
            {
                text.levelForINternational = "Level ";
                text.playButton = _en.GetComponent<Button>();
            }
        }
    }
}
