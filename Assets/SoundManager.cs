using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip shootBubbleSound, shootBigBubbleSound, bubblePopSound, jumpSound, bubbleJumpSound, bubbleChargeSound, stepOnEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayNormalJump();
        PlayNormalShot();
    }

    void PlayNormalJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.PlayOneShot(jumpSound);
        }
    }

    void PlayNormalShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.PlayOneShot(shootBubbleSound);
        }
    }
}
