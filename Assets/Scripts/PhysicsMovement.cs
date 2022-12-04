using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Walk(Vector2 localDirection)
    {
        localDirection.Normalize();
        _rigidbody.MovePosition(_rigidbody.position + (transform.right * localDirection.x + transform.forward * localDirection.y) * _speed * Time.deltaTime);
    }
}
