using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempShowUp : MonoBehaviour
{
    Text text;

    public IEnumerator EnableTextForTime(float _time)
    {
        text.enabled = true;
        yield return new WaitForSeconds(_time);
        text.enabled = false;
    }

    public void Awake()
    {
        text = GetComponent<Text>();
    }
}
