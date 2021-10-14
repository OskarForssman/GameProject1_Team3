using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{


    [System.Serializable] public struct Sources
    {
        public AudioSource bubbleCharge;
        public AudioSource bubbleJump;
        public AudioSource jump;
        public AudioSource enemyStepOn;
        public AudioSource damage;
        public AudioSource shot;
        public AudioSource pop;
    };
    public Sources sources = new Sources { };

    [HideInInspector] public float charge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        /*
        PlayNormalJump();
        PlayNormalShot();
        PlayChargeShot();
        */


    }

    public void PlaySound(AudioSource _source)
    {
        _source.PlayOneShot(_source.clip);
    }




}
