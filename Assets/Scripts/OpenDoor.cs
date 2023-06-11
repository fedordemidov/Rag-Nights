using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : InteractebleBase
{
    [Range(-180, 180)] [SerializeField] private float _openAngle = -100.0f;
    [SerializeField] private Transform _rotatingLeaf;
    [SerializeField] private Transform _doorFrame;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private AnimationCurve _animationCurve;
    private Coroutine _rotateCoroutine;

    public override void OnInteract()
    {
        base.OnInteract();
        Toggle();
    }

    private IEnumerator Rotate(float start, float end)
    {
        for (float i = 0; i < 1; i += Time.deltaTime * rotationSpeed)
        {
            transform.localRotation = Quaternion.Lerp(
            Quaternion.Euler(-90, 0, start),
            Quaternion.Euler(-90, 0, end),
            _animationCurve.Evaluate(i));

            yield return null;
        }

        transform.localRotation = Quaternion.Euler(-90, 0, end);
        _rotateCoroutine = null;
    }

    private float GetCurrentAngle()
    {
        float currentAngle = Quaternion.Angle(_doorFrame.localRotation, _rotatingLeaf.transform.localRotation);
        currentAngle *= _openAngle > 0 ? 1 : -1;
        return currentAngle;
    }

    private enum DoorState
    {
        Undefined,
        Open,
        Close,
    }

    private DoorState GetDoorState(float angle)
    {
        if (Mathf.Approximately(0, angle))
            return DoorState.Close;

        if (Mathf.Approximately(_openAngle, angle))
            return DoorState.Open;

        return DoorState.Undefined;
    }

    public void Open()
    {
        var currentAngle = GetCurrentAngle();

        if (GetDoorState(currentAngle) == DoorState.Open)
            return;

        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);

        _rotateCoroutine = StartCoroutine(Rotate(currentAngle, _openAngle));
    }

    public void Close()
    {
        var currentAngle = GetCurrentAngle();

        if (GetDoorState(currentAngle) == DoorState.Close)
            return;

        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);

        _rotateCoroutine = StartCoroutine(Rotate(currentAngle, 0));
    }

    public void Toggle()
    {
        var currentAngle = GetCurrentAngle();
        if (GetDoorState(currentAngle) == DoorState.Close)
            Open();
        else if (GetDoorState(currentAngle) == DoorState.Open)
            Close();
    }
}