using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyed : MonoBehaviour
{
    void OnDestroy()
    {
        if (GameObject.Find("HighScoreManager"))
        {
            GameObject.Find("HighScoreManager").GetComponent<HighScoreManager>().AmountKilled(gameObject.tag);
        }
       
    }
}
