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
    
        

    }

    public void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ai.inputVector.x = input;


    }
}

