using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerPromo : MonoBehaviour
{
    public Camera[] Camers;
    void Start()
    {
        Time.timeScale = 0.6f;

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
        foreach (Camera cams in FindObjectsOfType<Camera>())
        {
            if (cams.tag == "Camera0")
                Camers[0] = cams;
            if (cams.tag == "Camera1")
                Camers[1] = cams;
            if (cams.tag == "Camera2")
                Camers[2] = cams;
            if (cams.tag == "Camera3")
                Camers[3] = cams;
            if (cams.tag == "Camera4")
                Camers[4] = cams;
        }
        CameraManager(0);
        //StartCoroutine(Callbacks());
       
    }
   public void CameraManager(int index)
    {
            for (int i = 0; i < Camers.Length; i++)
            {
            if (Camers[i] != null)
            {
                if (i == index)
                {
                    Camers[i].enabled = true;
                }
                else
                    Camers[i].enabled = false;
            }
            }
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            CameraManager(1);
        if (Input.GetKeyUp(KeyCode.Keypad1))
            CameraManager(0);
        if (Input.GetKeyDown(KeyCode.Keypad2))
            CameraManager(2);
        if (Input.GetKeyUp(KeyCode.Keypad2))
            CameraManager(0);

    }
    //IEnumerator Callbacks()
    //{

    //    //yield return new WaitForSeconds(0.1f);

    //    //foreach (Camera cams in FindObjectsOfType<Camera>())
    //    //{
    //    //    if (cams.tag == "Camera0")
    //    //        Camers[0] = cams;
    //    //    if (cams.tag == "Camera1")
    //    //        Camers[1] = cams;
    //    //    if (cams.tag == "Camera1")
    //    //        Camers[2] = cams;
    //    //}
    //    //CameraManager(0);
    //}
}
