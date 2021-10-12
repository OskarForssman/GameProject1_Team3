using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfCollideWithPlayer : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float colliderRadius;
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, colliderRadius, enemyLayerMask);

        if (hit.Length > 0)
        {
            Destroy(gameObject);
        }
}
}