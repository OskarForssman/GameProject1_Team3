using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{

    public Volume volume;
    private Bloom bloom;

    void Start()
    {
        // read the bloom from the volume
        volume.profile.TryGet(out bloom);

        // change the color of the light
        //bloom.tint.value = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            RandomizeLight();
        }
    }


    public void RandomizeLight()
    {
        bloom.tint.value = Random.ColorHSV(0f, 1f, 0.7f, 0.7f, 0.5f, 0.7f);
    }
}
