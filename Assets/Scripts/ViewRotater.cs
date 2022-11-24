using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ViewRotater : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private float _speedRotation;

    [Header("Vertical rotation boundary")]
    [SerializeField] private float _minVerticalRotation = -80;
    [SerializeField] private float _maxVerticalRotation = 80;

    [Header("Sensevity")]
    public float horizontalSensevity;
    public float verticalSensevity;

    private Rigidbody _rigidbody;
    private float _horizontalRotation, _verticalRotation;
    private float _destinationHorizontalRotation, _destinationVerticalRotation;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.rotation = Quaternion.AngleAxis(_horizontalRotation, transform.up);
        _head.localRotation = Quaternion.AngleAxis(_verticalRotation, Vector3.right);

        _horizontalRotation = Mathf.Lerp(_horizontalRotation, _destinationHorizontalRotation, Time.deltaTime * _speedRotation);
        _verticalRotation = Mathf.Lerp(_verticalRotation, _destinationVerticalRotation, Time.deltaTime * _speedRotation);
    }

    public void Rotate(Vector3 eulerRotation)
    {
        Vector3 newRotation = Vector3.Scale(eulerRotation, (Vector3.right * horizontalSensevity + Vector3.up * verticalSensevity));

        _destinationHorizontalRotation += newRotation.x;
        _destinationVerticalRotation += newRotation.y;
        _destinationVerticalRotation = Mathf.Clamp(_destinationVerticalRotation, _minVerticalRotation, _maxVerticalRotation);
    }
}
