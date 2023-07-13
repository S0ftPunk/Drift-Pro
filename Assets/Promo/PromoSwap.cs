using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromoSwap : MonoBehaviour
{
    public GameObject[] cars;
   public void CarChanger(int index)
    {
        for(int i = 0; i <= 4; i++)
        {
            if (i == index)
            {
                cars[i].SetActive(true);
            }
            else
                cars[i].SetActive(false);
        }
    }
}
