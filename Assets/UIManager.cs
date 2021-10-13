using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // The texts of UI message
    public UnityEngine.UI.Text health;
    public UnityEngine.UI.Text enemyNeedToDefeat;
    public UnityEngine.UI.Text time;
    private Stats stats;

    private GameObject player;
    private WaveManager waveManager;

    
    void Start()
    {
       // get the objects that storing the needed information
       player = GameObject.Find("PlayerFish");
       stats = player.GetComponent<Stats>();
       GameObject waveManagerObj = GameObject.Find("EnemySpawnerManager");
       waveManager = waveManagerObj.GetComponent<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIMsg();    
    }

    // Update the UI information
    private void UpdateUIMsg()
    {
        // get the health value from player(Stats) to UI
        string healthValue = stats.health.ToString();
        health.text = healthValue;

        // get the left enemies number from WavaManager 
        string leftEnemies = waveManager.enemiesLeft.ToString();
        enemyNeedToDefeat.text = leftEnemies;

        // get the left time from WavaManager 
        string leftTime = waveManager.timeLeftOfWave.ToString();
        time.text = leftTime;
        
    }
}
