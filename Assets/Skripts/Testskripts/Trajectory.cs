using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public Transform Car;
    public CarTypeManager tm;
    public GameObject practicle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BuildTrajectory());
    }

    // Update is called once per frame
    void Update()
    {
        Car = tm.car.transform;
    }
    IEnumerator BuildTrajectory()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            Instantiate(practicle, Car.position, practicle.transform.rotation);
        }

    }
}
