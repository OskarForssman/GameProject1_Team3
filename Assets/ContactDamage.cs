using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    Stats stats;
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
        if (!stats.isTrapped)
        {
            RaycastHit hit;
            Vector3 yOffset = new Vector2(0, colliderOffsetY);
            if (Physics.SphereCast(transform.position + transform.right * colliderOffsetX + yOffset, colliderRadius, -transform.right, out hit, dist, playerLayerMask))
            {
                Stats s = hit.transform.GetComponent<Stats>();
                s.TakeDamage(1);
            }
        }
        
    }

    public void OnDrawGizmos()
    {
        Vector3 yOffset = new Vector2(0, colliderOffsetY);
        Gizmos.DrawWireSphere(transform.position + transform.right * colliderOffsetX + yOffset, colliderRadius);
        Gizmos.DrawWireSphere(transform.position - transform.right * colliderOffsetX + yOffset, colliderRadius);
    }

    public void Awake()
    {
        stats = GetComponent<Stats>();
    }
}
