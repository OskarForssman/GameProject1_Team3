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

    public void JumpToPlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamesDesignRoom");
    }

    public void JumpToControlScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ControlScene");
    }

    public void JumpToHighScoreScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HighScoreScene");
    }

    public void JumpToCreditsScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
