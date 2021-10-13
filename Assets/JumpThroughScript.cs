using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThroughScript : MonoBehaviour
{
     public  BoxCollider collider;
  
   
    private void Update()
    {
       float player= GameObject.Find("PlayerFish").GetComponent<PlayerMovement>().velocity.y;
       float frog=GameObject.Find("Frog").GetComponent<PlayerMovement>().velocity.y;
        CheckIFColliderActive(player);
        CheckIFColliderActive(frog);

    }


    // Update is called once per frame
    public void CheckIFColliderActive(float jump)
    {
        
        if (jump>0)
        {
            gameObject.layer = 13;
        }
        //else the collision will not be ignored
        else
        {
            gameObject.layer = 6;
        }
    }
}
