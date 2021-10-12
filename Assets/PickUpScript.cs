using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float colliderRadius;
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, colliderRadius, enemyLayerMask);
        if (hit.Length > 0)
        {
            Debug.Log(hit[0]);
           //TODO utifrån vad dem hittar gör ngt!
        }
        
    }
}
