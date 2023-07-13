using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTypeManager : MonoBehaviour
{
    int carType;
   /* public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;*/

    public GameObject[] cars;

    public Camera cam;
    public GameObject car;
    public Transform spawn;

    [SerializeField] DriveScript driveScript;
    // Start is called before the first frame update
   private void Start()
    {
        carType = PlayerPrefs.GetInt("carType");
        CarChanger(cars[carType - 1]);
        if (car != null)
        {
            driveScript = car.GetComponent<DriveScript>();
            if (PlayerPrefs.GetFloat("bestTime" + SceneManager.GetActiveScene().buildIndex) == 0)
                driveScript.nextButton.gameObject.SetActive(false);
            else
                driveScript.nextButton.gameObject.SetActive(true);
        }
    }
    void CarChanger(GameObject Car)
    {
        car = Instantiate(Car,spawn.position,spawn.rotation);
        //cam.GetComponent<CameraController>().car = Car.transform;
        cam.GetComponent<CameraController>().target = car.transform.Find("CameraTarget");
    }
    private void Update()
    {
            if (Input.GetKey(KeyCode.Space))
                driveScript.SpaceDown();
            if (Input.GetKeyUp(KeyCode.Space))
                driveScript.SpaceUp();

            if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
                driveScript.GetAxisButton(-1);
            else if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
                driveScript.GetAxisButton(1);
            else if(Input.GetKeyUp(KeyCode.A) | Input.GetKeyUp(KeyCode.D) | Input.GetKeyUp(KeyCode.RightArrow)| Input.GetKeyUp(KeyCode.LeftArrow))
                driveScript.GetAxisButton(0);
//Proomo
        //if (Input.GetKey(KeyCode.LeftShift))
        //    Time.timeScale = 0;
        //else if (Input.GetKey(KeyCode.Escape))
        //    Time.timeScale = 1;
    }
}
