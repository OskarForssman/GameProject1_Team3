using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBubble : MonoBehaviour
{
    public float bubblepopinthisamountofsec = 5f;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float colliderRadius;
    [SerializeField] bool willTrap; //Wether or not this bubble will trap hit enemies


    public void Update()
    {
        //Destroy(gameObject, bubblepopinthisamountofsec);

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, colliderRadius, Vector3.down, out hit, 0.01f, enemyLayerMask))
        {
            if (!willTrap)
            {
                Stats s = hit.transform.GetComponent<Stats>();
                if (!s.isResistant)
                {
                    s.TakeDamage(1);
                    Debug.Log("hit enemy");
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("couldnt hit enemy");
                    Destroy(gameObject);
                }
                

            }

            if (willTrap)
            {
                //Insert code that traps the enemy inside the bubble
                
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }



    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
