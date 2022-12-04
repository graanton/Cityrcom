using System.Collections;
using UnityEngine;

public class DigitalJoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystic;
    [SerializeField] private PhysicsMovement _movement;

    private void Update()
    {
        _movement.Walk(_joystic.Direction);
    }
}
