using UnityEngine;

namespace Tests
{
    public class ViewRotaterTester : MonoBehaviour
    {
        [SerializeField] private ViewRotater _viewRotater;
        [SerializeField] private float _speedRotate;
        [SerializeField] private Vector3 _rotateDirection;

        void Update()
        {
            _viewRotater.Rotate(_rotateDirection * _speedRotate * Time.deltaTime);
        }
    }
}