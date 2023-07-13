using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material mat_laser;
    public Material mat_line;

    Color red;
    Color purple;
    Color yellow;
    Color blue;

    int emissionColorId;
    int ColorId;

    // Start is called before the first frame update
    void Start()
    {
        red = new Color(1, 0.1028366f, 0);
        purple = new Color(0.9133019f, 0, 1);
        yellow = new Color(0.9945474f,1, 0.5518868f);
        blue = new Color(0.5529412f, 1, 0.9955755f);
        //emissionColorId = Shader.PropertyToID("_EmissionColor");
        ColorId = Shader.PropertyToID("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        Color currentColor = Color.Lerp(red, purple, (Mathf.Sin(Time.time) + 1) / 2);
        Color currentColor2 = Color.Lerp(yellow, blue, (Mathf.Sin(Time.time) + 1) / 2);
        /*mat_laser.SetColor(emissionColorId, currentColor * 1 );
        mat_line.SetColor(emissionColorId, currentColor2);*/
        mat_laser.SetColor(ColorId, currentColor);
        mat_line.SetColor(ColorId, currentColor2);
    }
}
