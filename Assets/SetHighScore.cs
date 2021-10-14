using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHighScore : MonoBehaviour
{
    // Start is called before the first frame update
   
  
    int highscoreNow=0;
    void Start()
    {
      
      int incomingHighscore=  PlayerPrefs.GetInt("CurrentHighScore");
        highscoreNow = PlayerPrefs.GetInt("HighScore");
        if (incomingHighscore > highscoreNow)
        {
            PlayerPrefs.SetInt("HighScore", incomingHighscore);
        }

        Debug.Log(PlayerPrefs.GetInt("HighScore"));
    }

   
}
