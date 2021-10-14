
using UnityEngine;
using UnityEngine.UI;

public class AddText : MonoBehaviour
{
  public  Text textLevel;
    public Text textPoints;
    void Start()
    {
        textLevel.text= PlayerPrefs.GetInt("CurrentHighScore").ToString();
        textPoints.text = PlayerPrefs.GetInt("CurrentWave").ToString();


    }
 

   
}
