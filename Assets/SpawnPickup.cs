using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
    [SerializeField] Transform spawnPointFolder; //Drag and drop a folder with children objects to set spawnpoints
    [SerializeField] GameObject[] popup;
    public Vector2[] spawnPoints;
    // Start is called before the first frame update+
    
    List<GameObject> popups;
    
   
    void Start()
    {
        spawnPoints = SetSpawnPoints(spawnPointFolder);
       
        popups = new List<GameObject>();
    }

    // Update is called once per frame
  
    

   public  void SpawnPopup()
    {


        int random1 = Random.Range(1,10);
        if (getAmountofCHilds(random1) <= 0)
        {
            SpawnRandomPickUp(random1);
        }

        int random2 = Random.Range(1, 10);
        if (getAmountofCHilds(random2) <= 0)
        {
            SpawnRandomPickUp(random2);
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
        
       
       
           GameObject Activepopup = Instantiate(popup[Random.Range(0, 5)], spawnPoints[whichSpawnPoint], Quaternion.identity);
           popups.Add(Activepopup);
         




    }
   
    public void DestroyPopup()
    {
       
        for (int i = 0; i < popups.Count; i++)
        {
            Destroy(popups[i]);
        }
        popups.Clear();


    }





    private int  getAmountofCHilds(int x)
    {
        return   spawnPointFolder.GetChild(x - 1).childCount; 
    }
}
