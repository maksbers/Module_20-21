using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private const KeyCode RotateShipLeft = KeyCode.Q;
    private const KeyCode RotateShipRight = KeyCode.W;
    private const KeyCode RotateMastLeft = KeyCode.A;
    private const KeyCode RotateMastRight = KeyCode.S;

    [SerializeField] private Rotator _shipRotator;
    [SerializeField] private Rotator _mastRotator;
  

    private void Update()
    {
        UpdateShipRotation();
        UpdateMastRotation();
    }

    private void UpdateShipRotation()
    {
        float shipDirection = 0f;

        if (Input.GetKey(RotateShipLeft))
            shipDirection -= 1f;

        if (Input.GetKey(RotateShipRight))
            shipDirection += 1f;

        if (_shipRotator != null)
            _shipRotator.SetInputDirection(shipDirection);
    }

    private void UpdateMastRotation()
    {
        float mastDirection = 0f;

        if (Input.GetKey(RotateMastLeft))
            mastDirection -= 1f;

        if (Input.GetKey(RotateMastRight))
            mastDirection += 1f;

        if (_mastRotator != null)
            _mastRotator.SetInputDirection(mastDirection);
    }
}
