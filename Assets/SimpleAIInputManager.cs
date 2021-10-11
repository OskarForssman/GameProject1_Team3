using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAIInputManager : UnitInputs
{
    ///Simple AI function that moves back and forth
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] public bool moveornot;
    [SerializeField] GameObject player;
    PlayerMovement movment;

    [SerializeField] bool jumper;
    [SerializeField] bool tadpoolRunawayFromPlayer;
    [SerializeField] int DistanceToRunAwayFROM;


    public void Start()
    {


        movment = GetComponent<PlayerMovement>();

        inputVector.x = 1;
       

    }

    public void Update()
    {
       if (inputVector.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
       if(tadpoolRunawayFromPlayer && Vector3.Distance(player.transform.position, gameObject.transform.position)< DistanceToRunAwayFROM)
        {
           
            RunAround(inputVector.x *= -1);
            
        }
      else 
        {
                RunAround(inputVector.x);
            
           
            


        }
        if (jumper)
        {
            movment.CanJump(movment.GroundCheck());
        }
       


    }

  


 void RunAround(float  dir)
    {
        Ray ray = new Ray(transform.position, Vector2.right * dir);
        if (Physics.Raycast(ray, 1f, groundLayerMask))
        {

            inputVector.x *= -1;





        }
    }
   
  

}
