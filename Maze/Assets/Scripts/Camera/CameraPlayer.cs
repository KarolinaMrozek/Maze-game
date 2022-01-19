using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    public GameObject objectFollow;
    public Vector3 offSet;

    public int rotateSpeed = 100;


    void Update()
    {
        transform.position = objectFollow.transform.position + offSet;


        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

    }

}
