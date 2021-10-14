using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTrapper : MonoBehaviour
{
    public Transform trappedTransform;
    private Stats trappedStats;
    SoundManager sound;

    public void Awake()
    {
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void Update()
    {
        if (trappedTransform != null)
        {
            trappedTransform.position = transform.position;
        }
    }

    public void DamageTrapped()
    {
        Debug.Log("doublepop");
        trappedStats.TakeDamage(6);
        sound.PlaySound(sound.sources.bubbleJump);
    }

    public void SetTrapped(Transform _transform)
    {
        trappedTransform = _transform;
        trappedStats = trappedTransform.GetComponent<Stats>();
        trappedStats.isTrapped = true;
    }

    public void UnsetTrapped()
    {
        trappedTransform = null;
        trappedStats.isTrapped = false;
    }
}
