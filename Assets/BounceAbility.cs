using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAbility : MonoBehaviour
{

    public LayerMask enemyLayerMask;

    CharacterController controller;
    PlayerMovement movement;
    Stats stats;

    [SerializeField] float bounciness;


    public void Awake()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
        stats = GetComponent<Stats>();
    }

    public void Update()
    {
        float groundCheckLength = controller.height / 2 - controller.radius + controller.skinWidth + 0.01f; //Positions the bubble to be just below the charactercontroller bottom capsule collider ball
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, controller.radius, Vector3.down, out hit, groundCheckLength, enemyLayerMask)) //Projects a sphere straight down at the bottom of the controller collider
        {
            //Compares the raycastHits team in the Stats class to tell if you arent on the same team to allow a bounce
            if (movement.velocity.y < 0 && hit.transform.GetComponent<Stats>())
            {
                Stats s = hit.transform.GetComponent<Stats>();
                if (!s.isTrapped)
                {
                    //TODO: add a brief bounce cooldown
                    movement.Bounce(bounciness);
                    s.TakeDamage(3);
                }
                    
            }
            
            
        }
    }
    
}
