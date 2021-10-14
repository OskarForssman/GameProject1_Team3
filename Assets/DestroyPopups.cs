using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPopups : MonoBehaviour
{
    public float DestroyTimer;
  

    
    float timer;
    private void Start()
    {
        timer = DestroyTimer;
    }



    void Update()
    {

      

       
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {

            DestroyPopupsNow();




        }
        




    }
    void DestroyPopupsNow()
    {

        Destroy(gameObject);
        timer = DestroyTimer;
               
    }




}

