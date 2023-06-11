using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractebleBase : MonoBehaviour, IInteractble
{
    [Header("Interacteble Settings")]
    [SerializeField] private float holdDuration = 1f;
    [Space]
    [SerializeField] private bool holdInteract = true;
    [SerializeField] private bool multipleUse = false;
    public bool isInteractable = true;
    [SerializeField] private string tooltipMessage = "Press E";

    public float HoldDuration => holdDuration;
    public bool HoldInteract => holdInteract;
    public bool MultipleUse => multipleUse;
    public bool IsInteractable => isInteractable;
    public string TooltipMessage => tooltipMessage;

    public virtual void OnInteract()
    {
        //Debug.Log("INTERACTED" + gameObject.name);
    }
}
