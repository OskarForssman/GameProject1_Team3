using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    int currentHighScore;
   
    void Start()
    {
      int currentHighScore=  Getint("HighScore");
        
    }

   public void SetCurrentHighScore(int HighScore)
    {
        if(HighScore> currentHighScore)
        {
            currentHighScore = HighScore;
            SetInt("HighScore",currentHighScore);
            //Set highscorescenen
        }
    }

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
        //Set highscorescenen
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
