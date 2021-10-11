using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTrapper : MonoBehaviour
{
    public Transform trappedTransform;

    public void Update()
    {
        if (trappedTransform != null)
        {
            trappedTransform.position = transform.position;
        }
    }
}
