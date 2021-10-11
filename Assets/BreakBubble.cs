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
        Destroy(gameObject, bubblepopinthisamountofsec);


        Collider[] hit = Physics.OverlapSphere(transform.position, colliderRadius, enemyLayerMask);
        if (hit.Length != 0)
        {
            if (!willTrap)
            {
                Stats s = hit[0].transform.GetComponent<Stats>();
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
    
    /*
    public void OnCollisionEnter(Collision collision)
    {
            if (!willTrap)
            {
                Stats s = collision.transform.GetComponent<Stats>();
            if (s != null)
            {
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
    */
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }



    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
