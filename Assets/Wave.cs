using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
    [Header("Time:")]
    [Tooltip("How much time you'll have to finish the wave ")]
    public float timeToCompleteWave;

    [Header("Spawn Intervals:")]
    [Tooltip("How many enemies will spawn from this wave")]
    public int enemiesPerWave;

    [Tooltip("How many enemies can exist on screen at the same time")]
    public int enemiesOnScreen;

    [Tooltip("The time interval between enemy spawns")]
    public float enemySpawnInterval;

    [Header("Enemy Settings:")]
    [Tooltip("Drag and drop an enemy prefab in there and assign the weight (chance) for said thing to be chosen for spawning")]
    public WaveEnemy[] enemyPrefabList;

    public Transform spawnPointFolder;


    [System.Serializable]
    public class WaveEnemy
    {
        public GameObject prefab;
        public float weight;
    }
}
