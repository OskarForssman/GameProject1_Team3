using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimator : MonoBehaviour
{
    PlayerMovement move;
    Animator anim;

    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        move = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (move.grounded)
        {
            anim.Play("Jump", 0, 0);
        }
    }
}
