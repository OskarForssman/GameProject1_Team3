using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{

    int AmountOFtadKilled;
    int amountofFrogkilled;
    int amountofspikekilled;
    int amountofsnailkilled;

    public int PointsFrog, PointsTad, PointsSpike, PointsSnail;
    int HighScore;
    private void Awake()
    {
        AmountOFtadKilled = 0;
        amountofFrogkilled = 0;
        amountofspikekilled = 0;
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
                amountofspikekilled++;
                break;
        }
              
    }

    public void HighScoreThisRound(int waveindex)
    {
        HighScore = (amountofFrogkilled*PointsFrog)+(amountofsnailkilled*PointsSnail)+(AmountOFtadKilled*PointsTad)+(amountofspikekilled*PointsSpike);
        HighScore = (HighScore * 100)*waveindex;
        PlayerPrefs.SetInt("CurrentHighScore", HighScore);
       
        Debug.Log("MyHighScore: "+HighScore);

        AmountOFtadKilled = 0;
        amountofFrogkilled = 0;
        amountofspikekilled = 0;
        amountofsnailkilled = 0;
        HighScore = 0;
    }
  

   

}
