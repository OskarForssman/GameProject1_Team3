using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
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

    public void Start()
    {
        spawnPoints = SetSpawnPoints(spawnPointFolder);
    }

}
