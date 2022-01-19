using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;


    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Rigidbody clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            clone.AddForce(fwd * 1500f);
        }
    }
}
