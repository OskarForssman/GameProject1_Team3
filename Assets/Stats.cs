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
    public Team team = Team.player;
}
