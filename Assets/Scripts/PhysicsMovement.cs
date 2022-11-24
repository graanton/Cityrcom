using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed = 5;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 input = _joystick.Direction;
        Vector3 moveDirection = transform.right * input.x + transform.forward * input.y;

        Move(moveDirection * Time.deltaTime * _speed);
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction);
    }
}
