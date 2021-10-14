using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    string text;
    Text textComp;
    [SerializeField] WaveManager waveManager;

    private void Awake()
    {
        textComp = GetComponent<Text>();
    }
    public void Update()
    {
        int acText = waveManager.waveIndex + 1;
        string stText = acText.ToString();
        textComp.text = stText;

    }
}
