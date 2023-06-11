using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivate : InteractebleBase
{
    [SerializeField] private GameObject[] activateObjects;

    public override void OnInteract()
    {
        base.OnInteract();

        for (int i = 0; i < activateObjects.Length; i++)
        {
            activateObjects[i].SetActive(true);
        }

        isInteractable = false;
    }
}
