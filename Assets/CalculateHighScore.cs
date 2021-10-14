using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateHighScore : MonoBehaviour
{
    // Start is called before the first frame update
  private int higherScore;
    [SerializeField] public int FrogPoint, Snailpoint, Spikepoint, Tadpoint;


   public void setHighScorePointsThisRound(string nameofEnemy)
    {
        switch (nameofEnemy)
        {
            case "Frog":
                higherScore += FrogPoint;
                break;
            case "Snail":
                higherScore += Snailpoint;
                break;
            case "Spikepool":
                higherScore +=  Spikepoint;
                break;
            case "Tadpool":
                higherScore +=  Tadpoint;
                break;

        }


    }
    public int setTotalHighScore(int waves)
    {
        int CurrentHighScore = higherScore *= waves;
        higherScore = 0;
        return CurrentHighScore;
    }



}
