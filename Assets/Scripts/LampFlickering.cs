using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFlickering : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private float frequency;

    void Start()
    {
        
    }

    void Update()
    {
        if (Random.Range(0, 1000) <= frequency)
        {
            _light.enabled = false;
        }
        else
        {
            _light.enabled = true;
        }
    }
}
