using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
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

    UnitInputs input;
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
        input = GetComponent<UnitInputs>();
        controller = GetComponent<CharacterController>();
    }


    #endregion

    #region Methods

    public bool GroundCheck()
        ///Returns a bool by spherecasting beneath the charactercontroller to more elegantly groundcheck 
    {
        Ray downRay = new Ray(transform.position, Vector3.down);
        float groundCheckLength = controller.height / 2 - controller.radius + controller.skinWidth + 0.01f; //Positions the bubble to be just below the charactercontroller bottom capsule collider ball
        if (Physics.SphereCast(downRay, controller.radius, groundCheckLength, groundLayerMask)) //Projects a sphere straight down at the bottom of the controller collider
        {
            return true;
        }
        else
        {
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
            if (velocity.y > -maxFallSpeed)
            {
                velocity.y -= gravity * Time.deltaTime;
            }
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
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = pos;
    }

    public void Bounce(float _bounciness)
        ///Adds vertical velocity, TODO: Add a very brief bounce cooldown!
    {
        velocity.y = _bounciness;
        Debug.Log("BOING");
    }

    #endregion
}
