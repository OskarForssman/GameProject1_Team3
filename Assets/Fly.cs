using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{


    Vector3 f = Vector3.up;

    void Update()
    {

        gameObject.transform.Translate(f * 1.1f * Time.deltaTime, Space.World);

    }

}