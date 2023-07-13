using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DriveScript : MonoBehaviour
{
    public float MaxSpeed = 15;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;
    float Angle = 0;
    float partOfMaxspped;
    float lastSpeed;
    float index = 4;
    float steerInput = 0;
    bool isBraking = false;
    [SerializeField] GameObject[] wheels;
    private Vector3 MoveForce;
    public Button nextButton;
    //public CameraManagerPromo cM;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        partOfMaxspped = MaxSpeed * 0.75f;
        lastSpeed = MaxSpeed;
    }
    public void RotButton(int angle)
    {                       
        steerInput = angle;
    }
    public void BrakeRotButton(int angle)
    {
        steerInput = angle;
        index = 6;
        isBraking = true;
        //MaxSpeed = Mathf.Lerp(MaxSpeed, partOfMaxspped, Time.deltaTime * 2);
    }
    public void UpButtons()
    {
        steerInput = 0;
    }
    public void UpBrakeButtons()
    {
        isBraking = false;
        index = 4;
        steerInput = 0;
        //MaxSpeed = Mathf.Lerp(MaxSpeed, lastSpeed, Time.deltaTime * 2);
    }

    public void SpaceDown()
    {
        index = 6;
        isBraking = true;
    }
    public void SpaceUp()
    {
        isBraking = false;
        index = 4;
    }
    public void GetAxisButton(int angle)
    {
        steerInput = angle;
    }
    //Proomo
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "CameraTriger")
    //        cM.CameraManager(3);
    //    if (other.gameObject.tag == "CameraTriger3")
    //        cM.CameraManager(4);
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "CameraTriger2")
    //        cM.CameraManager(0);
    //}
    //Proomo
    // Update is called once per frame
    void Update()
    {
        ////
        /*steerInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space))
        {
            index = 6;
            isBraking = true;
        }
        else
        {
            isBraking = false;
            index = 4;
        }*/
            ///
            if (isBraking)
            MaxSpeed = Mathf.Lerp(MaxSpeed, partOfMaxspped, Time.deltaTime * 2);
        else
            MaxSpeed = Mathf.Lerp(MaxSpeed, lastSpeed, Time.deltaTime * 2);

        MoveForce += transform.forward * MaxSpeed * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        Angle = Mathf.Lerp(Angle, steerInput, Time.deltaTime * index);
        transform.Rotate(Vector3.up * Angle * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

        foreach (GameObject wheel in wheels)
        {
            //wheel.transform.Rotate(Vector3.up *( Angle * 1.5f * SteerAngle)* 0 * Time.deltaTime);
            Quaternion target = Quaternion.Euler(0, steerInput * index/2 * SteerAngle, 0);
            wheel.transform.localRotation = Quaternion.Slerp(wheel.transform.localRotation, target, Time.deltaTime*index/2);
        }

        if(transform.position.y <= -0.2)
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }   
}
