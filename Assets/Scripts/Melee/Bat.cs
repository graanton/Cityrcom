using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Bat : MeleeBase
{
    [SerializeField] private float _radius = 2;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _attackLayer;
    [SerializeField] private float _force = 1000;
 
    public override void StartAttacking()
    {
        Swing();
    }

    public override void StopAttacking()
    {
        throw new System.NotImplementedException();
    }

    private void Swing()
    {
        RaycastHit[] hits = Physics.SphereCastAll(_attackPoint.position, _radius, transform.forward);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(transform.forward * _force);
            }
        }
    }
}
