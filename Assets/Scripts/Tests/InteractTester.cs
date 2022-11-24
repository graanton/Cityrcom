using UnityEngine;

namespace Tests
{
    public class InteractTester : MonoBehaviour
    {
        [SerializeField] private IInteractble some;
        [SerializeField] private GameObject someGameObject;
        [SerializeField] private Interactor interactor;

        [SerializeField] private Transform _interactionPoint;
        [SerializeField] private float _interactRadius;
        [SerializeField] private LayerMask _interactMask;
        [SerializeField] private int _maxInteractions = 3;
        private Collider[] _colliders;

        private void Start()
        {
            _colliders = new Collider[_maxInteractions];
        }

        private void Update()
        {
            if (someGameObject.TryGetComponent(out some))
            {
                print(Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactRadius, _colliders, _interactMask));
                print("interacted");
            }
        }
    }
}