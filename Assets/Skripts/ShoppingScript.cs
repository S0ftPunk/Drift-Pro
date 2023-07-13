using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingScript : MonoBehaviour
{ public int[] costList = new int[4] {15,32,54,80 };
    public int carType;
    int balance;
    public Text costText;
    public Text balanceText;
    public GameObject costBlock;
    CarChanger carChanger;
    // Start is called before the first frame update
    void Start()
    {
        /*if (!PlayerPrefs.HasKey("1"))
        {
            PlayerPrefs.SetInt("1", 1);
        }*/
        carType = GetComponent<CarChanger>().carType;
        balance = PlayerPrefs.GetInt("balance");
        Draw();
        carChanger = GetComponent<CarChanger>();
    }
    private void Draw()
    {
        balanceText.text = balance.ToString();
        if (!PlayerPrefs.HasKey(carType.ToString()))
        {
            costText.text = costList[carType - 2].ToString();
            costBlock.SetActive(true);
        }
        else
        {
            costBlock.SetActive(false);
        }
    }
    public void CostChanger()
    {
        carType = GetComponent<CarChanger>().carType;
        Draw();
    }
    public void BuyButton()
    {
        if (costList[carType - 2] <= balance)
        {
            balance -= costList[carType - 2];
            PlayerPrefs.SetInt("balance", balance);
            PlayerPrefs.SetInt(carType.ToString(), 1);
            Draw();
            carChanger.CarManager(carType);
        }
    }
}
