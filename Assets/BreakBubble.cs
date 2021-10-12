using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBubble : MonoBehaviour
{
    SoundManager sound;
    public float bubblepopinthisamountofsec = 5f;
    private float timeLeft;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float colliderRadius;
    [SerializeField] bool willTrap; //Wether or not this bubble will trap hit enemies

    [SerializeField] BubbleTrapper trapper;

    
    public void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, colliderRadius, enemyLayerMask);
        if (hit.Length != 0)
        {
            Stats s = hit[0].transform.GetComponent<Stats>();
            if (!willTrap)
            {
                if (!s.isTrapped)
                {
                    if (!s.bubbleImmunity)
                    {
                        s.TakeDamage(1);
                        Debug.Log("hit enemy");
                        DestroyBubble();
                    }
                    else
                    {
                        DestroyBubble();
                    }
                }
                
            }

            if (willTrap && trapper?.trappedTransform == null && !s.isTrapped) //Trap if havent trapped already, and only trap if the enemy isnt trapped
            {
                trapper.SetTrapped(hit[0].GetComponent<Transform>());
            }

            timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            DestroyBubbleSafe();
        }

        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            DestroyBubbleSafe();
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



    public void DestroyBubbleSafe() //Destroys bubble except trapped is safe
    {
        if (trapper != null && trapper.trappedTransform != null)
        {
            trapper.UnsetTrapped();
        }
        Destroy(gameObject);
    }

   
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
        timeLeft = bubblepopinthisamountofsec;
        sound = FindObjectOfType<SoundManager>();
        
    }

    void OnBecameInvisible()
    {
        DestroyBubble();
    }

    public void OnDestroy()
    {
        //sound.PlayBubbleJumpSound();
        
    }
}
