using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
    [SerializeField] Transform spawnPointFolder; //Drag and drop a folder with children objects to set spawnpoints
    [SerializeField] GameObject[] popup;
    public Vector2[] spawnPoints;
    // Start is called before the first frame update+
    [SerializeField] float timertospawnpopup;
    float timeLeft;
    void Start()
    {
        spawnPoints = SetSpawnPoints(spawnPointFolder);
         timeLeft = timertospawnpopup;
    }

    // Update is called once per frame
    void Update()
    {
      

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SpawnPopup();
        }
       
    }

    

    void SpawnPopup()
    {
        if (getAmountofCHilds(1) <= 0)
        {
            SpawnRandomPickUp(1);
        }
        if (getAmountofCHilds(2) <= 0)
        {
            SpawnRandomPickUp(2);
        }

    }

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

    private void SpawnRandomPickUp(int whichSpawnPoint)
    {
        
        int rand = Random.Range(0, spawnPoints.Length);
       
           GameObject Activepopup = Instantiate(popup[rand], spawnPoints[whichSpawnPoint], Quaternion.identity);
           Activepopup.transform.SetParent(spawnPointFolder.GetChild(whichSpawnPoint-1));
        timeLeft = timertospawnpopup;


    }

    private int  getAmountofCHilds(int x)
    {
        return   spawnPointFolder.GetChild(x - 1).childCount; ;
    }
}
