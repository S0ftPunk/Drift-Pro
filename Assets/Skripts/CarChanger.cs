using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChanger : MonoBehaviour
{
    public GameObject[] bolids;
    GameObject bolid;
    public int carType;
    public Transform spawnPoint;
    ManagerScene manager;
    void Awake()
    {
        carType = PlayerPrefs.GetInt("carType");

        CarSpawn();
        manager = GetComponent<ManagerScene>();
    }
    public void CarManager(int type)
    {
        if (PlayerPrefs.HasKey(carType.ToString()))
        {
            PlayerPrefs.SetInt("carType", type);
        }
    }
    void CarSpawn()
    {
        if(bolid != null)
        {
            Destroy(bolid);
        }
        bolid = Instantiate(bolids[carType - 1], spawnPoint.position, spawnPoint.rotation);
    }
    public void CarChangeButton(int i)
    {
        
        if(carType == 1 & i == -1)
        {
            carType = 5;
        }
        else if(carType == 5 & i == 1)
        {
            carType = 1;
        }
        else
            carType += i;
        Debug.Log(PlayerPrefs.GetInt("carType"));
        CarSpawn();
        CarManager(carType);
    }
}
