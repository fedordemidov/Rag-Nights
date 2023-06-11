using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Interaction Data", menuName = "InteractionSystem/InteractionData")]
public class InteractebleData : ScriptableObject
{
    private InteractebleBase m_interacteble;

    public InteractebleBase Interacteble
    {
        get => m_interacteble;
        set => m_interacteble = value;
    }

    public void Interact()
    {
        m_interacteble.OnInteract();
        ResetData();
    }

    public bool IsSameInteracteble(InteractebleBase _newInteracteble)
    {
        return m_interacteble == _newInteracteble;
    }

    public bool IsEmpty()
    {
        return m_interacteble == null;
    }

    public void ResetData()
    {
        m_interacteble = null;
    }
}
