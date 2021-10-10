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


  
    public void Start()
    {


        movment = GetComponent<PlayerMovement>();

        inputVector.x = 1;
       

    }

    public void Update()
    {

       
       
       
        Ray ray = new Ray(transform.position, Vector2.right * inputVector.x);
        if (Physics.Raycast(ray, 1f, groundLayerMask))
        {

              inputVector.x *= -1;
           

            
            
            
        }
        if (gameObject.transform.name == "Enemy")
        {
            movment.CanJump(movment.GroundCheck());
        }
       


    }

  


 
   
  

}
