using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float colliderRadius;
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, colliderRadius, enemyLayerMask);
        if (hit.Length > 0)
        {
          



                         switch (hit[0].tag)
            {
                case "Cannon":
                    Debug.Log("Cannon");
                    break;
                case "Invincible":
                    Debug.Log("Invincible");
                    break;
                case "HP":
                    Debug.Log("HP");
                    break;
                case "Random":
                    Debug.Log("Random");
                    break;
                case "Stone":
                    Debug.Log("Stone");
                    break;
            }

        }
        
    }
}
