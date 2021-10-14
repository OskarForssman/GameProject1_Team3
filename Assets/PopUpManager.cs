using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
      public float timerbfrspawn;
    SpawnPickup pickUp;
    bool trigger;
    // Start is called before the first frame update
    float timer;

    void Start()
    {
      
        pickUp = GetComponent<SpawnPickup>();
        spawnthepopus();
       
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            if (!trigger)
            {
                destroyThePopups();
            }
            else
            {
                spawnthepopus();
               
            }
               
            
         
                   

        }

      
   

    }
    void spawnthepopus()
    {
        
        pickUp.SpawnPopup();
        trigger = false;
        timer = timerbfrspawn;
    }

    void destroyThePopups()
    {
        pickUp.DestroyPopup();
        trigger = true;
        timer = timerbfrspawn;

    }

    private IEnumerator Countdown3()
    {
        
            yield return new WaitForSeconds(3); 


       
    }
}
