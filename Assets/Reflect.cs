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
            float dot = (pos.x * myDir.x) + (pos.y * myDir.y);
            Vector2 newDirection = myDir - (2 * (dot) * pos);
            ShootBubble bulletz = GetComponent<ShootBubble>();
            bulletz.shoot(newDirection);
            myDir = newDirection;

        }
    }
  
}
