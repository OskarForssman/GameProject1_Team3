using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [Header("General Stats:")]

    public int health;

    [SerializeField] bool isPlayer;

    [Tooltip("How long this character will be immune after taking damage")]
    [SerializeField] float damageInvuln;
    float damageInvulnLeft;

    public float bounceCooldown; //The brief period you cannot bounce on something

    public event Action deathEvent; //WaveManager subscribes to this event and reduce the enemy counter

    [Header("Enemy Immunities:")]

    [Tooltip("If this one wont be affected by small bubbles")]
    public bool bubbleImmunity; //This one is immune to small bubbles

    [Tooltip("If this one will simply shrug off being jumped on")]
    public bool bounceImmunity;

    [Tooltip("If this one will hurt you if you try to jump on it")]
    public bool spiky;


    public bool isTrapped;

    public bool isBubble;

    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject damageParticle;
    PlayerMovement movement;
    SoundManager sound;

 

    public void Update()
    {
        damageInvulnLeft -= Time.deltaTime;
    }


    public void Awake()
    {
        if (GetComponent<BreakBubble>())
        {
            BreakBubble breakBubble = GetComponent<BreakBubble>();
            deathEvent += breakBubble.DestroyBubble;
        }
        if (GetComponent<PlayerMovement>())
        {
            movement = GetComponent<PlayerMovement>();
        }
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void setInval(float time)
    {
        damageInvulnLeft = time;
    }

    public void TakeDamage(int _DMGAmount)
    {
        if (damageInvulnLeft <= 0)
        {
            if (movement != null) { movement.velocity.y = 5f; } //Not pretty that it's hardcoded buuut
            if (damageParticle != null) { Instantiate(damageParticle, transform.position, Quaternion.identity); }
            damageInvulnLeft = damageInvuln;
            health -= _DMGAmount;
            sound.sources.damage.PlayOneShot(sound.sources.damage.clip);
            sound.sources.damage.pitch = UnityEngine.Random.Range(0.7f, 0.9f);
            if (health <= 0)
            {
                //sound.sources.bubbleCharge.PlayOneShot(sound.sources.bubbleCharge.clip);
                sound.PlaySound(sound.sources.pop);
                Die();
            }
        }
        
    }
    

    public void Die()
    {
        deathEvent?.Invoke();
        Instantiate(deathParticle, transform.position, Quaternion.identity); //This causes an error since instantiating things when the scene unloads is kind of weird..
        if (isPlayer)
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene("endScene");
            GameObject gam = GameObject.Find("EnemySpawnerManager");
            WaveManager wav = gam.GetComponent<WaveManager>();
            if (GameObject.Find("HighScoreManager"))
            {
                GameObject.Find("HighScoreManager").GetComponent<HighScoreManager>().HighScoreThisRound(wav.waveIndex);
            }
            wav.EndGame();
        }
        Destroy(gameObject);
        
    }

}
