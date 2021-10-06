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

    #endregion


    #region Private Variables

    private Vector2 velocity;
    private bool grounded;

    InputManager input;
    CharacterController controller;

    #endregion

    #region Unity Methods
    public void Update()
    {
        
        Movement(input.inputVector.x);
        CanJump(input.jumpInput);
        AddGravity();
        ApplyMovement();
    }

    public void Awake()
    {
        input = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
    }

    #endregion

    #region Methods
    public void Movement(float _verticalInput)
        ///Sets horizontal velocity depending on given input
    {
        velocity.x = _verticalInput * moveSpeed; 
    }

    private void AddGravity()
        ///Adds downwards velocity if not grounded
    {
        if (!controller.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }
    }

    public void CanJump(bool _jumpInput)
        ///Jump.. from the ground
    {
        if (_jumpInput)
        {
            velocity.y = jumpSpeed;
        }
        
    }

    private void ApplyMovement()
        ///Applies velocity as controller movement. This method is put late in the update method
    {
        controller.Move(velocity * Time.deltaTime);
    }

    #endregion
}
