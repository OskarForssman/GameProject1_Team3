using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitInputs : MonoBehaviour
{
    ///The abstract base class for any AI/Player control script. Will control PlayerMovement related scripts

    public Vector2 inputVector;
    public bool jumpInput;
    public bool spawnBubblebehind;
    public bool spawnBubbleforward;
    public bool shootReflectBubble;
}
