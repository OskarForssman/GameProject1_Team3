using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    WaveManager waveManager;

    [SerializeField] Transform spawnPointFolder; //Drag and drop a folder with children objects to set spawnpoints

    public Vector2[] spawnPoints;





    private Vector2[] SetSpawnPoints(Transform _spawnPointFolder)
        //Returns spawnpoints as Vector2s with given transform/folder that has its own children
    {
        Transform[] childTransforms = _spawnPointFolder.GetComponentsInChildren<Transform>();
        Vector2[] _spawnPoints = new Vector2[childTransforms.Length];
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = childTransforms[i].position;
        }
        return _spawnPoints;
    }

    public void SpawnEnemy(Wave _wave)
    {
        int randomIndex = Random.Range(1, spawnPoints.Length);
        waveManager.enemiesOnScreen++;
        
        GameObject gam = Instantiate(GetRandomEnemy(_wave), spawnPoints[randomIndex], Quaternion.identity);
        Stats _stats = gam.GetComponent<Stats>();
        _stats.deathEvent += waveManager.ReduceEnemyCount;
    
    }

    private GameObject GetRandomEnemy(Wave _wave)
    {
        float totalWeight = 0;
        //Add the total weight in the enemyPrefabList
        foreach (var enemy in _wave.enemyPrefabList)
        {
            totalWeight += enemy.weight;
        }

        //Randomizes a value between 0 and the totalWeight
        float randomWeight = Random.Range(0, totalWeight);

        //Checks the rolled weight through the prefab List
        foreach (var _enemy in _wave.enemyPrefabList)
        {
            if (_enemy.weight >= randomWeight)
            {
                return _enemy.prefab;
            }
            else
            {
                randomWeight -= _enemy.weight;
            }
        }
        
        //If all else it will retrieve the last instance in the prefab list
        return _wave.enemyPrefabList[_wave.enemyPrefabList.Length-1].prefab;
        
    }

    public void Awake()
    {
        waveManager = GetComponent<WaveManager>();

    }

    public void Start()
    {
        spawnPoints = SetSpawnPoints(spawnPointFolder);
    }

}
