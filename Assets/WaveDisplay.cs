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
        text = waveManager.waveIndex.ToString();
        textComp.text = text;

    }
}
