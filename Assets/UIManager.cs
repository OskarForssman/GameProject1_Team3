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

    private GameObject player;
    private GameObject waveManager;

    
    void Start()
    {
       // get the objects that storing the needed information
       player = GameObject.Find("Player");
       waveManager = GameObject.Find("EnemySpawnerManager");
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
        string healthValue = player.GetComponent<Stats>().health.ToString();
        health.text = healthValue;

        // get the left enemies number from WavaManager 
        string leftEnemies = waveManager.GetComponent<WaveManager>().enemiesLeft.ToString();
        enemyNeedToDefeat.text = leftEnemies;

        // get the left time from WavaManager 
        string leftTime = waveManager.GetComponent<WaveManager>().timeLeftOfWave.ToString();
        time.text = leftTime;
        
    }
}
