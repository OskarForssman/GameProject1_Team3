using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField] float colliderRadius;
    [SerializeField] float colliderOffsetX;
    [SerializeField] float colliderOffsetY;
    [SerializeField] LayerMask playerLayerMask;
    float dist;

    public void Start()
    {
        dist = Vector2.Distance(transform.right * colliderOffsetX, -transform.right * colliderOffsetX);
    }

    public void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position + transform.right * colliderOffsetX, colliderRadius, -transform.right, out hit, dist, playerLayerMask))
        {

        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + transform.right * colliderOffsetX, colliderRadius);
        Gizmos.DrawWireSphere(transform.position - transform.right * colliderOffsetX, colliderRadius);
    }
}
