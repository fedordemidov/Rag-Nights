using UnityEngine;

public interface IInteractble
{
    float HoldDuration { get; }
    bool HoldInteract { get; }
    bool MultipleUse { get; }
    bool IsInteractable { get; }
    string TooltipMessage { get; }

    void OnInteract();
}