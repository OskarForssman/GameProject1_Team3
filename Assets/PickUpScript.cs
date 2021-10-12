using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float colliderRadius;
    ShotBubbleThatReflect reflect;
    [SerializeField] int hpgain;
    [SerializeField] float inviciblesec;
    [SerializeField] float bubblechargetime;
    [SerializeField] float stonesec;
    Stats stats;
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
                    Debug.Log("Cannon");
                    reflect.bubbleChargeTime=bubblechargetime;
                    break;
                case "Invincible":
                    Debug.Log("Invincible");
                    stats.setInval(inviciblesec);
                      break;
                case "HP":
                    Debug.Log("HP");
                    stats.getHp(hpgain);
                    break;
                case "Random":
                    Debug.Log("Random");
                    break;
                case "Stone":
                    Debug.Log("Stone");
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
