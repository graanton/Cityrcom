using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Gun : WeaponBase
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadTime;
    

    [SerializeField] private float _hitForce = 3000;

    private bool _isShooting;
    private IEnumerator _shooting;

    public override int count => throw new System.NotImplementedException();

    public override LootData lootData => _weaponData;

    public override int haveAmmo => throw new System.NotImplementedException();

    public override void StartShooting()
    {
        if (_isShooting == false)
        {
            _isShooting = true;
            if (_shooting == null)
            {
                _shooting = Shooting();
            }
            StartCoroutine(_shooting);
        }
    }

    private IEnumerator Shooting()
    {
        switch (_weaponData.cartridgeType)
        {
            case (GunCartridgeType.automatic):
                while (_isShooting)
                {
                    Shoot();
                    yield return new WaitForSeconds(1f / _fireRate);
                }
                break;

            case (GunCartridgeType.semiAutomatic):
                Shoot();
                yield return null;
                break;
        }
    }

    public override void StopShooting()
    {
        _isShooting = false;
        _shooting = null;
    }

    private void Shoot()
    {
        bool hited = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit);
        if (hited && hit.collider.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.AddForceAtPosition((hit.point - transform.position) * _hitForce, hit.point);
        }
    }
}