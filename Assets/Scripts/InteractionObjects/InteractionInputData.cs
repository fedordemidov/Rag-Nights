using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Input Data", menuName = "InteractionSystem/InputData")]
public class InteractionInputData : ScriptableObject
{
    private bool m_interactedClicked;
    private bool m_interactedRelease;

    public bool InteractedClicked
    {
        get => m_interactedClicked;
        set => m_interactedClicked = value;
    }

    public bool InteractedRelease
    {
        get => m_interactedRelease;
        set => m_interactedRelease = value;
    }

    public void Reset()
    {
        m_interactedClicked = false;
        m_interactedRelease = false;
    }
}
