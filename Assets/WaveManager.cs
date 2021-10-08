using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    SpawnManager spawning;

    #region Public Variables

    public Wave[] waveList; //This is not a wave list, this is a wave array!! Preposterous
    public int enemiesLeft; //How many enemies that need to be defeated until next wave
    public int enemiesOnScreen;

    #endregion


    #region Private Variables

    private int waveIndex = 0; //What wave is it right now
    private float timeLeftOfWave; //How long until you lose the wave
    private Wave currentWave; //The data for the current wave


    IEnumerator SpawnIntervalCoroutine(float _spawnInterval)
    {
        while (3 == 3)
        {
            yield return new WaitForSeconds(0.1f);
            while (enemiesOnScreen <= currentWave.enemiesOnScreen && enemiesLeft >= 0)
            {
                yield return new WaitForSeconds(_spawnInterval);
                spawning.SpawnEnemy(currentWave);
            }
        }
        
        
    }
    Coroutine spawnIntervalRoutine;

    #endregion


    private void WaveSetUp()
    {
        SetWave(0);
        
    }

    private void SetWave(int _waveIndex)
    {
        currentWave = waveList[_waveIndex];
        timeLeftOfWave = currentWave.timeToCompleteWave;
        enemiesLeft = currentWave.enemiesPerWave;
        spawnIntervalRoutine = StartCoroutine(SpawnIntervalCoroutine(currentWave.enemySpawnInterval));
    }

    private void NextWave()
    {
        waveIndex++;
        waveIndex = Mathf.Clamp(waveIndex, 0, waveList.Length-1);
        SetWave(waveIndex);
    }

    public void ReduceEnemyCount()
    {
        enemiesLeft--;
        enemiesOnScreen--;
        if (enemiesLeft <= 0 && enemiesOnScreen <= 0)
        {
            NextWave();
        }
    }

    public void Awake()
    {
        spawning = GetComponent<SpawnManager>();
    }

    public void Start()
    {
        WaveSetUp();

        
    }


}
