using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
   
  
    Vector2 myDir;
  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enviroment")
        {
            
            Vector2 pos = collision.collider.ClosestPoint(transform.position).normalized;
            Vector3 newDirection=Vector3.Reflect(collision.collider.ClosestPoint(transform.position), pos);
            ShootBubble bulletz = GetComponent<ShootBubble>();
            bulletz.shoot(newDirection);
            Debug.Log(newDirection);
            myDir = newDirection;
           
        }
    }
  
}
