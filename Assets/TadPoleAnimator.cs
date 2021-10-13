using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TadPoleAnimator : MonoBehaviour
{
    CharacterController character;
    Animator anim;

    public void Awake()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (character.velocity.y <= -0.1)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }
        
    }
}
