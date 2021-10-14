using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manag : MonoBehaviour
{
    public AudioSource audioo;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioo.Play();
        }
    }
}
