using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public float timebefredestroyPopup;
    public float timerbfrspawn;
    SpawnPickup pickUp;
    bool trigger;
    // Start is called before the first frame update
    float timerspawn;

    void Start()
    {
        pickUp = GetComponent<SpawnPickup>();
        timerspawn = timerbfrspawn;
         trigger=true;
    }

    // Update is called once per frame
    void Update()
    {
       
        timerspawn -= Time.deltaTime;
        if (timerspawn <= 0.0f)
        {
            if (trigger)
            {
                spawnthepopus();
            }
            else
            {
                destroyThePopups();
            }
         
                   

        }

      
   

    }
    void spawnthepopus()
    {
        pickUp.SpawnPopup();
        timerspawn = timerbfrspawn;
        trigger = false;
    }

    void destroyThePopups()
    {
        pickUp.DestroyPopup();
        timerspawn = timerbfrspawn;
        trigger = true;

    }
}
