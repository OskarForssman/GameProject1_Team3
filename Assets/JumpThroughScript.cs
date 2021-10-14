using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThroughScript : MonoBehaviour
{
     public  BoxCollider collider;
  
   
    private void Update()
    {
        if (GameObject.Find("PlayerFish"))
        {
            float player = GameObject.Find("PlayerFish").GetComponent<PlayerMovement>().velocity.y;
            CheckIFColliderActive(player);
        }
      

    }


    // Update is called once per frame
    public void CheckIFColliderActive(float jump)
    {
        
        if (jump>0)
        {
            //gameObject.layer = 13;
            collider.enabled = false;
        }
        //else the collision will not be ignored
        else
        {
            //gameObject.layer = 6;
            collider.enabled = true;
        }
    }
}
