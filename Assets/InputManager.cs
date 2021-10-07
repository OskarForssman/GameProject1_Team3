using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : UnitInputs
{
    ///Handles the players input
    

    public bool shootHoldInput;
    public bool shootReleaseInput;
    

    public void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetKeyDown(KeyCode.Space);
        spawnBubblebehind = Input.GetKeyDown(KeyCode.E);
        spawnBubbleforward = Input.GetKeyDown(KeyCode.R);
        shootReflectBubble = Input.GetKeyDown(KeyCode.Mouse1);

    }
}
