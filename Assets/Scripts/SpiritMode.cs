using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMode : MonoBehaviour
{
    public bool canSpirit = false;
    public bool isSpirit = false;

    [SerializeField] private float spiritMaxTime = 1;
    [SerializeField] private float spiritTime;

    void Update()
    {
        if (Input.GetButton("Fire1") && canSpirit)
        {
            if (spiritTime > 0)
            {
                isSpirit = true;
            }
        }
        else
        {
            isSpirit = false;
        }

        if (isSpirit)
            spiritTime -= Time.deltaTime;
        else
            spiritTime += Time.deltaTime / 2;

        if (spiritTime > spiritMaxTime)
            spiritTime = spiritMaxTime;

        if (spiritTime <= 0)
        {
            spiritTime = 0;
            isSpirit = false;
        }  
    }
    
    void OnCollisionStay(Collision col)
    {
        if (isSpirit && col.gameObject.layer == 7)
        {
            col.collider.isTrigger = true;
        }
        else
        {
            col.collider.isTrigger = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 7)
        {
            col.isTrigger = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (!isSpirit)
        {
            col.isTrigger = false;
        }
    }
}
