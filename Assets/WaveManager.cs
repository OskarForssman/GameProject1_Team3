using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    SpawnManager spawning;


    public Wave[] waveList; //This is not a wave list, this is a wave array!! Preposterous

    private int waveIndex = 0; //What wave is it right now

    private int enemiesLeft; //How many enemies that need to be defeated until next wave

    private float timeLeftOfWave; //How long until you lose the wave

    private Wave currentWave; //The data for the current wave




    private void SetWave(int _waveIndex)
    {
        currentWave = waveList[_waveIndex];
        timeLeftOfWave = currentWave.timeToCompleteWave;
    }

    private void NextWave()
    {
        waveIndex++;
        SetWave(waveIndex);
    }

    public void Awake()
    {
        spawning = GetComponent<SpawnManager>();
    }

    public void Start()
    {
        SetWave(0);
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawning.SpawnEnemy(currentWave);
            Debug.Log("omg haiii");
        }
    }

}
