using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetHighScore : MonoBehaviour
{
    // Start is called before the first frame update

    public Text text;
    int highscoreNow=0;
    void Start()
    {
      
      int incomingHighscore=  PlayerPrefs.GetInt("CurrentHighScore");
        highscoreNow = PlayerPrefs.GetInt("HighScore");
        if (incomingHighscore > highscoreNow)
        {
            PlayerPrefs.SetInt("HighScore", incomingHighscore);
        }

       text.text=PlayerPrefs.GetInt("HighScore").ToString();
    }

   
}
