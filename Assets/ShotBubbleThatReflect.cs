using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBubbleThatReflect : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    CharacterController controller;
    UnitInputs input;
    private float nextFire = 0.0F;
    public float fireRate = 2F;
    [SerializeField] private Camera cam;
    [SerializeField]  GameObject smallbubble;
   
    public void Awake()
    {
        input = GetComponent<UnitInputs>();
        
    }
    void Update()
    {
        if (input.spawnBubblebehind && Time.time> nextFire)
        {
            nextFire = Time.time + fireRate;
            spawnBigJumpableBubble(-1);
        }
        if (input.spawnBubbleforward && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            spawnBigJumpableBubble(1);
        }
        if (input.shootReflectBubble)
        {
            shootSmallBubble();
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
}
