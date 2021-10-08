using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromBubble : MonoBehaviour
{
    Stats stats;
    SimpleAIInputManager ai;
    [SerializeField] public float StunBigbubblehowlong = 2F;
    private float nextFire = 0.0F;
    private void Awake()
    {
        stats = GetComponent<Stats>();
         ai = GetComponent<SimpleAIInputManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.tag == "Bubble")
        {
            Stats s = transform.GetComponent<Stats>();
          
               
                s.TakeDamage(1);
            
        }


        if (collision.transform.tag == "BigBubble")
        {
          
            GetComponent <SimpleAIInputManager> ().enabled = false;
            ai.inputVector.x = 0;
            if (Time.time > nextFire)
            {
                nextFire = Time.time + StunBigbubblehowlong;
              

            }
        }

    }
}

