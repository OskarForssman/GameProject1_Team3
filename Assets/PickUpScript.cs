using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float colliderRadius;
    ShotBubbleThatReflect reflect;
    [SerializeField] float inviciblesec;
    [SerializeField] float bubblechargetime;
    [SerializeField] float stonesec;
    Stats stats;
    WaveManager manager; 
    private void Awake()
    {
        reflect = GetComponent<ShotBubbleThatReflect>();
        stats = GetComponent<Stats>();
        manager = GetComponent<WaveManager>();
        //Cannonpowerupduration
        //stats
        
    }




    void OnControllerColliderHit(ControllerColliderHit hit)
    {
             
            switch (hit.transform.tag)
            {
                case "Cannon":
                reflect.bubbleChargeTime = bubblechargetime;
                Destroy(hit.gameObject);
                break;
                case "Invincible":
                    stats.setInval(inviciblesec);
                Destroy(hit.gameObject);
                break;
                case "HP":
                     stats.health=stats.health+1;
                Destroy(hit.gameObject);
                break;
                case "Random":

                Destroy(hit.gameObject);
                break;
                case "Stone":
                    gameObject.GetComponent<InputManager>().enabled = false;
                stats.setInval(stonesec);
                Destroy(hit.gameObject);
                StartCoroutine(Timer());

                    break;
            }

        
    
      
       
    }


      
    
    IEnumerator Timer()
    {
      

        
        yield return new WaitForSeconds(stonesec);
        gameObject.GetComponent<InputManager>().enabled = true;

    }
}
