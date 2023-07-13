using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_show : MonoBehaviour
{
    public int fps { get; private set; }
    [SerializeField]private Text _label;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FpsCounter());
    }
    IEnumerator FpsCounter()
    {
        while (true)
        { yield return new WaitForSeconds(0.3f);
          fps = (int)(1f / Time.unscaledDeltaTime);
        }     

    }
    // Update is called once per frame
    void Update()
    {
        //fps = (int)(1f / Time.unscaledDeltaTime);
        _label.text = fps.ToString();
    }
}
