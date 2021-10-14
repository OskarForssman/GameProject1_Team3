using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private int higherScore;
    [SerializeField] public int FrogPoint, Snailpoint, Spikepoint, Tadpoint;


    public void setHighScorePointsThisRound(string nameofEnemy)
    {
        Debug.Log("test");
        switch (nameofEnemy)
        {
            case "Frog":
                higherScore += FrogPoint;
                break;
            case "Snail":
                higherScore += Snailpoint;
                break;
            case "Spikepool":
                higherScore += Spikepoint;
                break;
            case "Tadpool":
                higherScore += Tadpoint;
                break;

        }
        Debug.Log(higherScore);


    }
  public  int setTotalHighScore(int waves)
    {
        int CurrentHighScore = higherScore *= waves;
        higherScore = 0;
        return CurrentHighScore;
    }
}
