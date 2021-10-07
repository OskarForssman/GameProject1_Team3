using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] int health;

    public float bounceCooldown; //The brief period you cannot bounce on something

    event Action deathEvent; //WaveManager subscribes to this event and reduce the enemy counter

    public enum Team
    {
        player,
        enemy
    }
    public Team team = Team.player; //What team said thing is on

    

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
        deathEvent.Invoke();
        Destroy(gameObject);
    }
}
