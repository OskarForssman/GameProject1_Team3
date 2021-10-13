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
    [SerializeField] float destroypopup;
    List<GameObject> popups;
    float timeLeft;
    float destroybubble;

    public bool spawnPopu;
    public bool destroypoopup;
    void Start()
    {
        spawnPoints = SetSpawnPoints(spawnPointFolder);
         timeLeft = timertospawnpopup;
        popups = new List<GameObject>();
    }

    // Update is called once per frame
  
    

   public  void SpawnPopup()
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
        
        int rand = Random.Range(0, 4);
       
           GameObject Activepopup = Instantiate(popup[rand], spawnPoints[whichSpawnPoint], Quaternion.identity);
           Activepopup.transform.SetParent(spawnPointFolder.GetChild(whichSpawnPoint-1));
           popups.Add(Activepopup);
        timeLeft = timertospawnpopup;




    }
   
    public void DestroyPopup()
    {
        for (int i = 0; i < popups.Count; i++)
        {
            Destroy(popups[i]);
            popups.RemoveAt(i);
        }


    }





    private int  getAmountofCHilds(int x)
    {
        return   spawnPointFolder.GetChild(x - 1).childCount; ;
    }
}
