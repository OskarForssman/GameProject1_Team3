using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{

    int AmountOFtadKilled;
    int amountofFrogkilled;
    int amountofspikekillec;
    int amountofsnailkilled;

    public int PointsFrog, PointsTad, PointsSpike, PointsSnail;
    int HighScore;
    private void Awake()
    {
        AmountOFtadKilled = 0;
        amountofFrogkilled = 0;
        amountofspikekillec = 0;
        amountofsnailkilled = 0;

    }
    public void AmountKilled(string tag)
    {
        switch (tag)
        {
            case "Frog":
                amountofFrogkilled++;
                break;
            case "Snail":
                amountofsnailkilled++;
                break;
            case "Tadpool":
                AmountOFtadKilled++;
                break;
            case "Spikepool":
                amountofspikekillec++;
                break;
        }
        Debug.Log(AmountOFtadKilled);
        
    }

    public void HighScoreThisRound(int wave)
    {
               HighScore = (AmountOFtadKilled*PointsTad) + (amountofspikekillec*PointsSpike) + (amountofsnailkilled*PointsSnail) + (amountofFrogkilled*PointsFrog);
               HighScore *= wave;
               Debug.Log("HighScore "+HighScore);
        AmountOFtadKilled = 0;
        amountofFrogkilled = 0;
        amountofspikekillec = 0;
        amountofsnailkilled = 0;
        HighScore = 0;
    }

}
