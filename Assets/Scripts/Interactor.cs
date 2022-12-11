using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactRadius;
    [SerializeField] private LayerMask _interactMask;
    [SerializeField] private int _maxInteractionInSphere = 5;

    private Collider[] _colliders;

    private void Start()
    {
        _colliders = new Collider[_maxInteractionInSphere];
    }

    public void Interact(IInteractble interaction)
    {
        interaction.Interact(this);
    }

    public bool CulculateNearestColliderInteraction(out Collider nearestColliderIntarction)
    {
        int interactionFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactRadius, _colliders, _interactMask);
        if (interactionFound == 0)
        {
            nearestColliderIntarction = null;
            return false;
        }

        Collider nearestCollider = _colliders[0];
        for (int colliderNumber = 0; colliderNumber < interactionFound; colliderNumber++)
        {
            bool isCloserThanBefore = Vector3.Distance(_interactionPoint.position, nearestCollider.transform.position) >
                Vector3.Distance(_interactionPoint.position, _colliders[colliderNumber].transform.position);
            if (isCloserThanBefore)
            {
                nearestCollider = _colliders[colliderNumber];
            }
        }

        nearestColliderIntarction = nearestCollider;
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactRadius);
    }
}
