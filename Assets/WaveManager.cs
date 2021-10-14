using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    SpawnManager spawning;
    [SerializeField] GameObject waveDisplayObject;

    #region Public Variables

    public Wave[] waveList; //This is not a wave list, this is a wave array!! Preposterous
    public int enemiesLeft; //How many enemies that need to be defeated until next wave
    public int enemiesOnScreen;
    public float timeLeftOfWave; //How long until you lose the wave
    public int waveIndex = 0; //What wave is it right now
    [SerializeField] float timeCap = 40;

    #endregion

    IEnumerator GameOverPauseCoroutine(float _time)
    {
        yield return new WaitForSeconds(_time);
        UnityEngine.SceneManagement.SceneManager.LoadScene("endScene");
    }
    Coroutine endRoutine;


    #region Private Variables

    
    
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

    IEnumerator DisplayNewWave(float _timeDisplayed)
    {
        waveDisplayObject.SetActive(true);
        yield return new WaitForSeconds(_timeDisplayed);
        waveDisplayObject.SetActive(false);
    }
    Coroutine displayWaveRoutine;

    #endregion


    private void WaveSetUp()
    {
        SetWave(0);
        
    }

    private void SetWave(int _waveIndex)
    {
        currentWave = waveList[_waveIndex];
        timeLeftOfWave += currentWave.timeToCompleteWave;
        timeLeftOfWave = Mathf.Min(timeLeftOfWave, timeCap);
        enemiesLeft = currentWave.enemiesPerWave;
        spawnIntervalRoutine = StartCoroutine(SpawnIntervalCoroutine(currentWave.enemySpawnInterval));
        displayWaveRoutine = StartCoroutine(DisplayNewWave(4.5f));
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

        /* 
         * Zeke: I replace the line 74 with line 76 so I could test the UI :)
         * 
        if (enemiesLeft <= 0 && enemiesOnScreen <= 0)
        */
        if (enemiesLeft <= 0)
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

    public void Update()
    {
        timeLeftOfWave -= Time.deltaTime;
        if (timeLeftOfWave <= 0)
        {
            Debug.Log("Times up!");
            EndGame();
        }
    }

    public void SetTimeLeftOnWave()
    {
        timeLeftOfWave = timeLeftOfWave + 5f;
    }

    public void EndGame()
    {
        endRoutine = StartCoroutine(GameOverPauseCoroutine(3f));
    }
}
