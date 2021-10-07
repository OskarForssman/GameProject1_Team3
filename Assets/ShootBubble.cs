using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBubble : MonoBehaviour
{
   [SerializeField] private Rigidbody rigid;

   


    public void shoot(Vector3 direction,int speed)
    {




        rigid.AddForce(direction*speed,ForceMode.VelocityChange);
      

    }


}
