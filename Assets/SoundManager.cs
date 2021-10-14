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
        PlayChargeShot();


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
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            
        }
    }

    void PlayChargeShot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            source.PlayOneShot(bubbleChargeSound);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            source.Stop();
            source.PlayOneShot(shootBubbleSound);
        }
    }

    public void PlayBubbleJumpSound()
    {
        source.PlayOneShot(bubbleJumpSound);
    }


}
