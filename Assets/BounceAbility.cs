using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAbility : MonoBehaviour
{

    public LayerMask unitLayerMask;

    CharacterController controller;
    PlayerMovement movement;

    [SerializeField] float bounciness;


    public void Awake()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        float groundCheckLength = controller.height / 2 - controller.radius + controller.skinWidth + 0.01f; //Positions the bubble to be just below the charactercontroller bottom capsule collider ball
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, controller.radius, Vector3.down, out hit, groundCheckLength, unitLayerMask)) //Projects a sphere straight down at the bottom of the controller collider
        {
            
            if (hit.transform.GetComponent<Stats>())
            {
                Debug.Log("Heyo");
                Stats s = hit.transform.GetComponent<Stats>();
                if (s.team == Stats.Team.enemy)
                {
                    movement.Bounce(bounciness);
                }
            }
            
            
        }
    }
    
}
