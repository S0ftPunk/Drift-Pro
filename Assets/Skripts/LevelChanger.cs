using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    public GameObject[] tracks;
    public int trackIndex;
    public int maxtrackIndex;
    public GameObject track;

    public Transform spawnPoint;
    public Text levelTextNumb;
    private ManagerScene managerScene;

    private int levelCoins;
    public Image[] coins;
    public Button playButton;

    public string levelForINternational;
    void Start()
    {
        for(int i = 1;i <= tracks.Length; i++)
        {
            if (PlayerPrefs.GetFloat("bestTime" + (i + 2)) == 0)
            {
                if (i == tracks.Length)
                {
                    trackIndex = i;
                    maxtrackIndex = 0;
                    break;
                }
                    
                trackIndex = i;
                maxtrackIndex = i + 1;
                break;
            }
            else if (i == tracks.Length)
                trackIndex = tracks.Length;
        }

        TrackSpawner();
        // levelTextNumb.text = "Level " + trackIndex.ToString();
        levelTextNumb.text = levelForINternational + trackIndex.ToString();
        managerScene = GetComponent<ManagerScene>();
        levelCoins = PlayerPrefs.GetInt("levelCoins" + (trackIndex + 2));
        //Debug.Log(PlayerPrefs.GetFloat("bestTime" + (trackIndex+2)));
        ShowCoins(levelCoins);
    }
    public void IndexChanger(int k)
    {
        if (maxtrackIndex != 0)
        {
            if (trackIndex == 1 & k == -1)
                trackIndex = maxtrackIndex;

            else if (trackIndex == maxtrackIndex & k == 1)
                trackIndex = 1;

            else
                trackIndex += k;
        }
        else
        {
            if (trackIndex == 1 & k == -1)
                trackIndex = tracks.Length;

            else if (trackIndex == tracks.Length & k == 1)
                trackIndex = 1;

            else
                trackIndex += k;
        }

        if (trackIndex == maxtrackIndex)
            playButton.interactable = false;

        else
            playButton.interactable = true;

        TrackSpawner();
        //levelTextNumb.text = "Level " + trackIndex.ToString();
        levelTextNumb.text = levelForINternational + trackIndex.ToString();
        levelCoins = PlayerPrefs.GetInt("levelCoins" + (trackIndex + 2));
        ShowCoins(levelCoins);
    }
    private void TrackSpawner()
    {
        if (track != null)
            Destroy(track);
        track = Instantiate(tracks[trackIndex - 1], spawnPoint.position, Quaternion.identity);
    }
    public void LevelOpen()
    {
        managerScene.SceneOpen(trackIndex + 2);
    }
    private void ShowCoins(int countOfCoins)
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].enabled = false;
        }
        for (int i = 0; i < countOfCoins;i++)
        {
            coins[i].enabled = true;
        }
    }
}
