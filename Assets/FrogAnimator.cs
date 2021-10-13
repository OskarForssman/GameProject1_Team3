using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimator : MonoBehaviour
{
    CharacterController chara;
    Animator anim;

    public void Awake()
    {
        chara = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (chara.isGrounded)
        {
            anim.Play("Jump", 0, 0);
        }
    }
}
