using System.Collections;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    private void Update()
    {
        _movement.Walk(Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical"));
    }
}
