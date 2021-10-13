using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    InputManager input;
    PlayerMovement move;
    CharacterController character;
    

    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        input = GetComponent<InputManager>();
        move = GetComponent<PlayerMovement>();
        character = GetComponent<CharacterController>();
    }

    public void Update()
    {
        if (input.inputVector.x != 0)
        {
            if (input.inputVector.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        anim.SetFloat("RiseOrFall", move.velocity.y);
        if (move.grounded) { anim.SetBool("Land", true); }
        else
        { anim.SetBool("Land", false); };
    }


}
