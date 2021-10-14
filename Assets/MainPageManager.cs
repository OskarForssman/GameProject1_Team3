using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jumpToPlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamesDesignRoom");
    }

    public void jumpToControlScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ControlScene");
    }

    public void jumpToHighScoreScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HighScoreScene");
    }


}
