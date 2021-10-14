using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
      public float timerbfrspawn;
    SpawnPickup pickUp;
   
    // Start is called before the first frame update
    float timer;

    void Start()
    {
      
        pickUp = GetComponent<SpawnPickup>();
        timer = timerbfrspawn;

    }
    private void Update()
    {


        if (getAmountOfpowerupsonMap() == 0)
        {
            timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
         
               
            spawnthepopus();




        }
        }
    }

    // Update is called once per frame

    public void spawnthepopus()
    {

        pickUp.SpawnPopup();
        timer = timerbfrspawn;
    }
   int getAmountOfpowerupsonMap()
    {
        int f = GameObject.FindGameObjectsWithTag("Stone").Length + GameObject.FindGameObjectsWithTag("HP").Length + GameObject.FindGameObjectsWithTag("Random").Length + GameObject.FindGameObjectsWithTag("Cannon").Length + GameObject.FindGameObjectsWithTag("Invincible").Length;
        return f;
    }




}
