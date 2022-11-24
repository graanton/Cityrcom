using System.Collections;
using UnityEngine;

namespace Tests
{
    public class ForceObjectSpawnerTester : MonoBehaviour, IInteractble
    {
        [SerializeField] private GameObject _forceObject;
        [SerializeField] private Transform _spawnPoint;

        public string interactionPrompt => string.Empty;

        public bool canInteraction => true;

        public void Interact(Interactor interactor)
        {
            Instantiate(_forceObject, _spawnPoint.position, Quaternion.identity);
        }
    }
}