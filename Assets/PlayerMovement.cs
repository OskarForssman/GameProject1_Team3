using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager input;

    [Header("Ground Stats:")]
    [SerializeField] private float moveSpeed;

    [Header("Aerial Stats:")]
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Awake()
    {
        input = GetComponent<InputManager>();
    }
}
