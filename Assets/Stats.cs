using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public enum Team
    {
        player,
        enemy
    }
    public Team team = Team.player; //What team said thing is on

    [SerializeField] int health;

    public float bounceCooldown; //The brief period you cannot bounce on something

    public void TakeDamage(int _DMGAmount)
    {
        health -= _DMGAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Pop");
        }
    }
}
