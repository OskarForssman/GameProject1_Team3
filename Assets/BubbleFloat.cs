using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFloat : MonoBehaviour
{
    [SerializeField] float floatAmount;

    Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        rb.AddForce(Vector3.up * floatAmount, ForceMode.VelocityChange);
    }
}
