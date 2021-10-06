using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIInputManager : UnitInputs
{
    [SerializeField] private LayerMask groundLayerMask;

    public void Start()
    {
        inputVector.x = 1;
    }

    public void Update()
    {
        Ray ray = new Ray(transform.position, Vector2.right * inputVector.x);
        if (Physics.Raycast(ray, 1f, groundLayerMask))
        {
            inputVector.x *= -1;
        }
        
    }
}
