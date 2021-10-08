using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBubble : MonoBehaviour
{
    public float bubblepopinthisamountofsec = 5f;
    private void Update()
    {
        Destroy(gameObject, bubblepopinthisamountofsec);
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.transform.tag == "Enviroment")
        {
            Destroy(gameObject);
        }
        */
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("hit enemy");

            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
