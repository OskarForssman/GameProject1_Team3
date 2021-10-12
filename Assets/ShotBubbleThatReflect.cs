using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBubbleThatReflect : MonoBehaviour
{
    
    CharacterController controller;
    InputManager input;
    private float nextFire = 0.0F;
    [SerializeField]  public float fireRateInsecbig = 2F;
    [SerializeField] public float fireRateInsecSmall = 0.2F;
    [SerializeField] private Camera cam;
    

    [Header("Small Bubble Properties:")]
    [SerializeField] float smallBubbleForce;
    [SerializeField] float smallFiringOffset;
    [SerializeField] GameObject smallbubble;

    [Header("Big Bubble Properties:")]
    [SerializeField] float bigBubbleForce;
    [SerializeField] float bigFiringOffset;
    [SerializeField] private GameObject bubble;

    [Header("Bubble Charging Properties:")]
    [SerializeField] float bubbleChargeTimeNeeded;
    public float bubbleChargeTime;
    public float cannonPWRUpDuration;
   
    public void Awake()
    {
        input = GetComponent<InputManager>();
        
    }
    void Update()
    {
        cannonPWRUpDuration -= Time.deltaTime;
        

        if (input.shootReleaseInput)
        {
            if (bubbleChargeTime == bubbleChargeTimeNeeded)
            {
                FireBubble(bubble, input.fireInputVector, bigBubbleForce, bigFiringOffset);
            }
            else
            {
                FireBubble(smallbubble, input.fireInputVector, smallBubbleForce, smallFiringOffset);
            }
            
        }

        if (input.shootHoldInput)
        {
            if (cannonPWRUpDuration > 0)
            {
                bubbleChargeTime += Time.deltaTime;
            }
            bubbleChargeTime += Time.deltaTime;
            bubbleChargeTime = Mathf.Clamp(bubbleChargeTime, 0, bubbleChargeTimeNeeded);
        }
        else
        {
            bubbleChargeTime = 0;
        }
    }
    private void spawnBigJumpableBubble(int x)
    {

        Instantiate(bubble, new Vector2(transform.position.x + x, transform.position.y), transform.rotation);

    }
    private void shootSmallBubble()
    {
        
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mousepos = cam.ScreenToWorldPoint(screenPosition);

            Vector2 mypos = transform.position;
            Vector3 directionVector = (mousepos - mypos).normalized;
       
        ShootBubble  bulletz = Instantiate(smallbubble, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), gameObject.transform.rotation)?.GetComponent<ShootBubble>();
            bulletz.shoot(directionVector,10);
        
    }

    private void FireBubble(GameObject _prefab, Vector3 _direction, float _force, float _offset)
    {
        GameObject gam = Instantiate(_prefab, transform.position + _direction * _offset, Quaternion.identity);
        Rigidbody rb = gam.GetComponent<Rigidbody>();
        rb.AddForce(_direction * _force, ForceMode.VelocityChange);
    }
}
