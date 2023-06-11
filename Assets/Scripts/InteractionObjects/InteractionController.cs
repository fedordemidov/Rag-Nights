using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float raySphereRadius;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask InteractebleLayer;

    private bool m_interacting;
    private float m_holdTimer = 0f;

    [SerializeField] private InteractebleData interactebleData;

    [Space, Header("UI")]
    [SerializeField] private InteractionUIPanel uiPanel;

    private void Awake()
    {
        
    }

    private void Update()
    {
        CheckForInteractable();
        CheckForInteractableInput();
    }

    void CheckForInteractable()
    {
        Ray _ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit _hitInfo;

        bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, InteractebleLayer);

        if (_hitSomething)
        {
            InteractebleBase _interacteble = _hitInfo.transform.GetComponent<InteractebleBase>();

            if (_interacteble != null)
            {
                if (interactebleData.IsEmpty())
                {
                    interactebleData.Interacteble = _interacteble;
                    uiPanel.SetToolTip(_interacteble.TooltipMessage);
                }
                else
                {
                    if (!interactebleData.IsSameInteracteble(_interacteble))
                    {
                        interactebleData.Interacteble = _interacteble;
                        uiPanel.SetToolTip(_interacteble.TooltipMessage);
                    }   
                }
            }
        }
        else
        {
            uiPanel.ResetUI();
            m_holdTimer = 0f;
            interactebleData.ResetData();
        }

        Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
    }

    void CheckForInteractableInput()
    {
        if (interactebleData.IsEmpty())
            return;

        if (Input.GetButtonDown("Interact"))
        {
            m_interacting = true;
            m_holdTimer = 0f;
        }

        if (Input.GetButtonUp("Interact"))
        {
            m_interacting = false;
            m_holdTimer = 0f;
            uiPanel.UpdateProgressBar(0f);
        }

        if (m_interacting)
        {
            if (!interactebleData.Interacteble.IsInteractable)
                return;

            if (interactebleData.Interacteble.HoldInteract)
            {
                m_holdTimer += Time.deltaTime;

                float holdPercent = m_holdTimer / interactebleData.Interacteble.HoldDuration;
                uiPanel.UpdateProgressBar(holdPercent);

                if (m_holdTimer >= interactebleData.Interacteble.HoldDuration)
                {
                    interactebleData.Interact();
                    m_interacting = false;
                }
            }
            else
            {
                interactebleData.Interact();
                m_interacting = false;
            }
        }
    }
}
