using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromBubble : MonoBehaviour
{
    Stats stats;

    private void Awake()
    {
        stats = GetComponent<Stats>();
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
            Stats s = transform.GetComponent<Stats>();


            s.TakeDamage(1);

        }

    }
}

