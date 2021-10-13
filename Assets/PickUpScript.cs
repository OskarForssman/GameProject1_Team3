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
            
                Destroy(GameObject.FindGameObjectWithTag(hit.transform.tag));
                    break;
                case "Invincible":
                    stats.setInval(inviciblesec);
                Destroy(GameObject.FindGameObjectWithTag(hit.transform.tag));
                break;
                case "HP":
                     stats.health=stats.health+1;
                Destroy(GameObject.FindGameObjectWithTag(hit.transform.tag));
                break;
                case "Random":
                
                Destroy(GameObject.FindGameObjectWithTag(hit.transform.tag));
                break;
                case "Stone":
                    gameObject.GetComponent<InputManager>().enabled = false;
                stats.setInval(stonesec);
                Destroy(GameObject.FindGameObjectWithTag(hit.transform.tag));
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
