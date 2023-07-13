using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSkript : MonoBehaviour
{
    private ManagerScene managerScene;
    private void Start()
    {
        managerScene = FindObjectOfType<ManagerScene>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DriveScript>() != null)
        {
            managerScene.AddShow();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
