using UnityEngine;

namespace Tests
{
    [RequireComponent(typeof(Rigidbody))]
    public class ForceObjectTester : MonoBehaviour, IInteractble
    {
        [SerializeField] private string _prompt;
        [SerializeField] private float _forcePower = 2000;
        public string interactionPrompt => _prompt;

        public bool canInteraction => true;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Interact(Interactor interactor)
        {
            _rigidbody.AddForce((transform.position - interactor.transform.position) * _forcePower);
        }
    }
}
