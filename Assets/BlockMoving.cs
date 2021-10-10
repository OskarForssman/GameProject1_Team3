using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlockMoving: MonoBehaviour
{
    private Vector3 startPos;
    public Vector3 endPos;
    public float speed;
    private bool moveUp;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x + 4f, startPos.y, startPos.z);
        moveUp = true;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
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
}
