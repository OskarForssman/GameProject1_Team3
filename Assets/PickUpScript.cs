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
    int increment;
    private void Awake()
    {
        reflect = GetComponent<ShotBubbleThatReflect>();
        stats = GetComponent<Stats>();
        //Cannonpowerupduration
        //stats
        
    }
    void Update()
    {
       
        Collider[] hit = Physics.OverlapSphere(transform.position, colliderRadius, enemyLayerMask);
        if (hit.Length > 0)
        {
         switch (hit[0].tag)
            {
                case "Cannon":
                    reflect.bubbleChargeTime=bubblechargetime;
                    break;
                case "Invincible":
                    stats.setInval(inviciblesec);
                      break;
                case "HP":
                  // stats.health++;
                    break;
                case "Random":
                      break;
                case "Stone":
                    gameObject.GetComponent<InputManager>().enabled = false;
                    StartCoroutine(Timer());

                    break;
            }

        }
        
    }
    IEnumerator Timer()
    {
      

        
        yield return new WaitForSeconds(stonesec);
        gameObject.GetComponent<InputManager>().enabled = true;

    }
}
