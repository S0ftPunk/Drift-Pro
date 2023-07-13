using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float speed = 14f;
    public bool isMain = false;

    private void Update()
    {
        if (!isMain)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.deltaTime);
        }
        //Proomo
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime*2);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.deltaTime*2);
        }
        //Proomo
    }
}
