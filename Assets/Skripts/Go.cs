using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go : MonoBehaviour
{
    // Settings
    public float MoveSpeed = 50;
    public float MaxSpeed = 15;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;
    float Angle = 0;
    float partOfMaxspped;
    float lastSpeed;
    float index = 4;
    // Variables
    private Vector3 MoveForce;
    void Start()
    {
        partOfMaxspped = MaxSpeed * 0.75f;
        lastSpeed = MaxSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Moving
        MoveForce += transform.forward * MaxSpeed * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;
        //Rb.AddForce(MoveForce);
        //Rb.velocity = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
        //Inputs
        if (Input.GetKey(KeyCode.Space))
        {
            //SteerAngle = 1.5f;
            //MaxSpeed = partOfMaxspped;
            //Drag = 0.985f;
             index = 6;
             MaxSpeed = Mathf.Lerp(MaxSpeed, partOfMaxspped, Time.deltaTime*2);
            //Traction = 0.3f;
    

        }
        else
        {
            //MaxSpeed = lastSpeed;
            //SteerAngle = 1;
            //Drag = 0.99f;
            index = 4;
            MaxSpeed = Mathf.Lerp(MaxSpeed, lastSpeed, Time.deltaTime*2);
            //Traction = 1.3f;
  

        }
        // Steering       
        float steerInput = Input.GetAxis("Horizontal");
        Angle = Mathf.Lerp(Angle, steerInput, Time.deltaTime*index);
        transform.Rotate(Vector3.up * Angle * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Drag and max speed limit
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        // Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
    }
}
