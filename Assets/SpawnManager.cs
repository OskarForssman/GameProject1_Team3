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
        int randomIndex = Random.Range(0, spawnPoints.Length);
        //Instantiates a random prefab(IT'S NOT RANDOM YET) at a random SpawnPoint
        GameObject gam = Instantiate(GetRandomEnemy(_wave), spawnPoints[randomIndex], Quaternion.identity);
    }

    private GameObject GetRandomEnemy(Wave _wave)
    {
        float totalWeight = 0;
        //Add the total weight in the enemyPrefabList
        for (int i = 0; i < _wave.enemyPrefabList.Length; i++)
        {
            totalWeight += _wave.enemyPrefabList[i].weight;
        }

        //Randomizes a value between 0 and the totalWeight
        float randomWeight = Random.Range(0, totalWeight);

        //
        for (int i = 0; i < _wave.enemyPrefabList.Length - 1; i++)
        {
            if (_wave.enemyPrefabList[i].weight < randomWeight && _wave.enemyPrefabList[i+1].weight >= randomWeight)
            {
                return _wave.enemyPrefabList[i].prefab;
            }
        }
        return null;
        
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
