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
        
    }

    private void Swing()
    {
        Collider[] hits = Physics.OverlapSphere( _attackPoint.position, _radius, _attackLayer);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(transform.forward * _force);
            }
        }
    }
}
