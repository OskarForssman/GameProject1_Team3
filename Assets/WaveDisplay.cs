using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    string text;
    public int waveCount;
    Text textComp;
    [SerializeField] WaveManager waveManager;

    private void Awake()
    {
        textComp = GetComponent<Text>();
    }
    public void Update()
    {
        int acText = waveCount + 1;
        string stText = acText.ToString();
        textComp.text = stText;

    }
}
