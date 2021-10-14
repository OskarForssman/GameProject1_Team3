using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage_PressAnyButton : MonoBehaviour
{

    public float noInputTimer = 0;


    public void Update()
    {
        noInputTimer -= Time.deltaTime;

        if (noInputTimer <= 0)
        {
            Debug.Log("Input now Awailable!");

            if (Input.anyKeyDown)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName: "MainPage");
            }
        }
    }
}
