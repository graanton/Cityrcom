using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private FOVTargetDetecter _detecter;
    [SerializeField] private float _viewRate = 15;
    [SerializeField] private float _timeToTargetLoss = 5;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine(ScaningForTarget());
    }

    private void Update()
    {
        if (_target != null)
        {
            _agent.SetDestination(_target.position);
        }
    }

    private IEnumerator ScaningForTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _viewRate);
            var targets = _detecter.ScanView();

            bool haveTargetInView = targets.Count > 0;
            if (haveTargetInView)
            {
                StopCoroutine(nameof(ScaningForTarget));
                _target = targets[0].transform;
            }
            else
            {
                if (_target != null)
                {
                    StartCoroutine(nameof(LosingOfTarget));
                }
            }
        }
    }

    private IEnumerator LosingOfTarget()
    {
        yield return new WaitForSeconds(_timeToTargetLoss);
        _target = null;
    }
}
