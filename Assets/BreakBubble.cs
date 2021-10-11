using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBubble : MonoBehaviour
{
    public float bubblepopinthisamountofsec = 5f;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float colliderRadius;
    [SerializeField] bool willTrap; //Wether or not this bubble will trap hit enemies

    [SerializeField] BubbleTrapper trapper;

    
    public void Update()
    {
        //Destroy(gameObject, bubblepopinthisamountofsec); //This skips the DestroyBubble method, so it never unsets the enemies isTrapped status


        Collider[] hit = Physics.OverlapSphere(transform.position, colliderRadius, enemyLayerMask);
        if (hit.Length != 0)
        {
            Stats s = hit[0].transform.GetComponent<Stats>();
            if (!willTrap)
            {
                
                if (!s.isResistant && !s.isTrapped)
                {
                    s.TakeDamage(1);
                    Debug.Log("hit enemy");
                    DestroyBubble();
                }
                /*
                else
                {
                    Debug.Log("couldnt hit enemy");
                    DestroyBubble();
                }
                */
                //Physics.Ignore
                

            }

            if (willTrap && trapper?.trappedTransform == null && !s.isTrapped) //Trap if havent trapped already, and only trap if the enemy isnt trapped
            {
                trapper.SetTrapped(hit[0].GetComponent<Transform>());
            }
        }
    }

    public void DestroyBubble()
    {
        if (trapper != null && trapper.trappedTransform != null)
        {
            trapper.DamageTrapped();
            trapper.UnsetTrapped();
        }
        
        Destroy(gameObject);
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

    public void Awake()
    {
        if (GetComponent<BubbleTrapper>())
        {
            trapper = GetComponent<BubbleTrapper>();
        }
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
