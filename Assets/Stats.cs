using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] public int health;

    public float bounceCooldown; //The brief period you cannot bounce on something

    public event Action deathEvent; //WaveManager subscribes to this event and reduce the enemy counter

    [Header("Immunities:")]

    [Tooltip("If this one wont be affected by small bubbles")]
    public bool bubbleImmunity; //This one is immune to small bubbles

    [Tooltip("If this one will simply shrug off being jumped on")]
    public bool bounceImmunity;

    [Tooltip("If this one will hurt you if you try to jump on it")]
    public bool spiky;

    

    /*
    public enum DamageStatus
    {
        Normal, //Can kill by jump and bubble
        Resistant, //Cannot jump or bubble, needs a big bubble
        Spiky, //Will hurt if you try to jump
    }
    public DamageStatus status;
    */

    public bool isTrapped;

    /*
    public enum Team
    {
        player,
        enemy
    }
    public Team team = Team.player; //What team said thing is on
    */

    public void Awake()
    {
        if (GetComponent<BreakBubble>())
        {
            BreakBubble breakBubble = GetComponent<BreakBubble>();
            deathEvent += breakBubble.DestroyBubble;
        }
        
    }


    public void TakeDamage(int _DMGAmount)
    {
        health -= _DMGAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        deathEvent?.Invoke();
        Destroy(gameObject);
    }
}
