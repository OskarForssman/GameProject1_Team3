using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : UnitInputs
{
    ///Handles the players input
    

    public bool shootHoldInput;
    public bool shootReleaseInput;

    public Vector2 fireInputVector;

    public void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        /*
        if (inputVector != Vector2.zero)
        {
            fireInputVector = inputVector;
        }
        */
        Vector2 i = Input.mousePosition;
        fireInputVector = Camera.main.ScreenToWorldPoint(i) - transform.position;
        
        fireInputVector.Normalize();
        

        jumpInput = Input.GetKeyDown(KeyCode.Space);
        spawnBubblebehind = Input.GetKeyDown(KeyCode.E);
        spawnBubbleforward = Input.GetKeyDown(KeyCode.R);
        shootReflectBubble = Input.GetKeyDown(KeyCode.Mouse1);

        shootHoldInput = Input.GetKey(KeyCode.Mouse0);
        shootReleaseInput = Input.GetKeyUp(KeyCode.Mouse0);


    }

}
