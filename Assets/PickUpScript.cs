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
    [SerializeField] GameObject wavemanger;
    WaveManager manager;
    public float timetoaddforWave;
    Stats stats;
   
    private void Awake()
    {
        reflect = GetComponent<ShotBubbleThatReflect>();
        stats = GetComponent<Stats>();
        



    }




    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        
        
            switch (hit.transform.tag)
            {
                case "Cannon":
                reflect.cannonPWRUpDuration = 10;
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
                wavemanger.GetComponent<WaveManager>().timeLeftOfWave= wavemanger.GetComponent<WaveManager>().timeLeftOfWave+ timetoaddforWave;
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
