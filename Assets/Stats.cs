using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("General Stats:")]

    public int health;

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

    /*
    public enum Team
    {
        player,
        enemy
    }
    public Team team = Team.player; //What team said thing is on
    */

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
        
    }

    public void setInval(float time)
    {
        damageInvulnLeft = time;
    }

    public void TakeDamage(int _DMGAmount)
    {
        if (damageInvulnLeft <= 0)
        {
            damageInvulnLeft = damageInvuln;
            health -= _DMGAmount;
            if (health <= 0)
            {
                Die();
            }
        }
        
    }
    public void getHp(int hp)
    {
      health=health+hp;
    }

    public void Die()
    {
        deathEvent?.Invoke();
        Destroy(gameObject);
    }
}
