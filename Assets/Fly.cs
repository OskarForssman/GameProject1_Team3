using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{


    Vector3 f = Vector3.up;

    [SerializeField] Rigidbody body;

    void Update()
    {

        body.AddRelativeForce(f * Time.deltaTime, ForceMode.VelocityChange);

    }

}