using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinisScript : MonoBehaviour
{
    float time = 0f;
    //float lastTime;
    float bestTime;
    bool isStarted = false;
    //bool isFinished = false;
    public string stringTime;
    public Text textTime;
    public Text bestTimeText;
    public Image bgText;

    public Image[] coins;
    public GameObject imageOfCoin;
    public Text balance;
    public Button nextButton;

    public float twoCoin;
    public float threeCoin;

    int countOfCoins;
    private void Start()
    {
        /*f (!PlayerPrefs.HasKey("bestTime" + SceneManager.GetActiveScene().buildIndex))
        {
            PlayerPrefs.SetFloat("bestTime" + SceneManager.GetActiveScene().buildIndex, 0f); //Переместить в тутор
        }*/
        //else
        bestTime = PlayerPrefs.GetFloat("bestTime" + SceneManager.GetActiveScene().buildIndex);
        /*if (!PlayerPrefs.HasKey("balance"))
        {
            PlayerPrefs.SetInt("balance", 0);//Переместить в тутор
        }*/
        countOfCoins = PlayerPrefs.GetInt("balance");
        balance.text = countOfCoins.ToString();
        if (bestTime != 0)
        {
            bestTimeText.enabled = true;
            bgText.enabled = true;
            bestTimeText.text = bestTime.ToString("0.##");
            Rate(bestTime);
            PlayerPrefs.SetInt("levelCoins" + SceneManager.GetActiveScene().buildIndex, Rate(bestTime));
        }      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<DriveScript>()!=null)
        {
            Debug.Log("enter");
            if (time != 0)
            {
                Debug.Log("Finished");
                if (bestTime > time | bestTime == 0)
                {
                    if (bestTime == 0)
                    {
                        if (FindObjectOfType<DriveScript>() != null)
                            nextButton = FindObjectOfType<DriveScript>().nextButton;
                        nextButton.gameObject.SetActive(true);
                    }
                    PlayerPrefs.SetFloat("bestTime" + SceneManager.GetActiveScene().buildIndex, time);
                    bestTime = time;
                    PlayerPrefs.SetInt("levelCoins" + SceneManager.GetActiveScene().buildIndex, Rate(time));
                }
                bestTimeText.text = stringTime;
                bestTimeText.enabled = true;
                bgText.enabled = true;
                Rate(time);
                countOfCoins += Rate(time);
                PlayerPrefs.SetInt("balance", countOfCoins);
                StartCoroutine(CoinHide());
            }
        }
    }
    IEnumerator CoinHide()
    {
        imageOfCoin.active = true;
        balance.text = countOfCoins.ToString();
        yield return new WaitForSeconds(1f);
        imageOfCoin.active = false;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DriveScript>() != null)
        {
            time = 0;
            Debug.Log("exit");
            isStarted = true;
        }
    }
    private int Rate(float time)
    {
        if (time <= twoCoin & time > threeCoin)
        {
            coins[0].enabled = true;
            coins[1].enabled = true;
            coins[2].enabled = false;
            return 2;
        }
        else if(time <= threeCoin)
        {
            coins[0].enabled = true;
            coins[1].enabled = true;
            coins[2].enabled = true;
            return 3;
        }
        else
        {
            coins[0].enabled = true;
            coins[1].enabled = false;
            coins[2].enabled = false;
            return 1;
        }
    }
    void Update()
    {
        if (isStarted)
        {
            time += Time.deltaTime;
        }
        stringTime = time.ToString("0.##");
        
    }
}
