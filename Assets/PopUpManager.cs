using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public float timebefredestroyPopup;
    public float timerbfrspawn;
    SpawnPickup pickUp;
    // Start is called before the first frame update
    float timerspawn, timerdestroy;

    void Start()
    {
        pickUp = GetComponent<SpawnPickup>();
        timerdestroy = timebefredestroyPopup;
        timerspawn = timerbfrspawn;

    }

    // Update is called once per frame
    void Update()
    {
        timerspawn -= Time.deltaTime;
        if (timerspawn <= 0.0f)
        {
            spawnthepopus();

        }


        timerdestroy -= Time.deltaTime;
        if (timerdestroy <= 0.0f)
        {
            destroyThePopups();
          
        }
   

    }
    void spawnthepopus()
    {
        pickUp.SpawnPopup();
        timerspawn = timerbfrspawn;
    }

    void destroyThePopups()
    {
        pickUp.DestroyPopup();
        timerdestroy = timebefredestroyPopup;
    }
}
