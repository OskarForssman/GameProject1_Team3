using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromBubble : MonoBehaviour
{
    Stats stats;
    SimpleAIInputManager ai;
    [SerializeField] float timeStunned;
 
    float input;
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

             input = ai.inputVector.x;
            ai.inputVector.x = 0;
            StartCoroutine(ExecuteAfterTime(timeStunned));




        }

    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ai.inputVector.x = input;


    }
}

