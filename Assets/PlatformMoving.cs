using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformMoving : MonoBehaviour
{
    private Vector3 startPos;
    public bool isPlatformMove;
    public float horizontalMovement;
    public float verticalMovement;
    public float moveSpeed;
    private Vector3 endPos;
    public bool isPlatformRotate;
    public float rotateSpeed;
    private bool moveUp;

    void Start()
    {
        startPos = transform.position;
        // sign the destination of movement
        endPos = new Vector3(startPos.x +horizontalMovement, startPos.y + verticalMovement, startPos.z);
        moveUp = true;
    }
        

    void Update()
    {

        if (isPlatformMove)
        {
            float step = moveSpeed * Time.deltaTime;
            if (transform.position == endPos)
            {
                moveUp = false;
            }
            else if (transform.position == startPos)
            {
                moveUp = true;
            }

            if (moveUp == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            }
            else if (moveUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            }
        }

        
        if (isPlatformRotate)
        {
            // self rotation
            gameObject.transform.Rotate(new Vector3(0, 0, rotateSpeed));
        }


    }
}
