using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [Header("Ground Stats:")]
    [SerializeField] private float moveSpeed;

    [Header("Aerial Stats:")]
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float maxFallSpeed;

    [SerializeField] private LayerMask groundLayerMask; 

    #endregion


    #region Private Variables

    private Vector2 velocity; 
    private bool grounded;

    #region References

    InputManager input;
    CharacterController controller;

    #endregion

    #endregion

    #region Unity Methods

    
    public void Update()
    {
        
        Movement(input.inputVector.x);

        grounded = GroundCheck();
        if (grounded)
        {
            CanJump(input.jumpInput);
        }
        else
        {
            AddGravity();
        }

        ApplyMovement();
    }

    public void Awake()
    {
        input = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
    }

    public void OnDrawGizmos()
    {
        CharacterController bruh = GetComponent<CharacterController>();
        float offset = bruh.height / 2 - bruh.radius / 2;
        Vector3 sphereLocation = transform.position + Vector3.down * offset;
        Gizmos.DrawWireSphere(sphereLocation, bruh.radius);

    }

    #endregion

    #region Methods

    public bool GroundCheck()
        ///Returns a bool by spherecasting beneath the charactercontroller to more elegantly groundcheck 
    {
        Ray downRay = new Ray(transform.position, Vector3.down);
        if (Physics.SphereCast(downRay, controller.radius, controller.height/2, groundLayerMask)) //Projects a sphere straight down at the bottom of the controller collider
        {
            Debug.Log("Ground!");
            return true;
            
        }
        else
        {
            Debug.Log("Air!");
            return false;
        }
    }

    public void Movement(float _verticalInput)
        ///Sets horizontal velocity depending on given input
    {
        velocity.x = _verticalInput * moveSpeed; 
    }

    private void AddGravity()
        ///Adds downwards velocity if not grounded
    {
        if (!grounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }
    }

    public void CanJump(bool _jumpInput)
        ///Jumps.. from the ground, if the given jumpInput is true
    {
        if (_jumpInput)
        {
            velocity.y = jumpSpeed;
        }
        
    }

    private void ApplyMovement()
        ///Applies velocity via the characterController move method. This method is put late in the update method
    {
        controller.Move(velocity * Time.deltaTime);
    }

    #endregion
}