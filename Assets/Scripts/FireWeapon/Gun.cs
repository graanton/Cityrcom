using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Gun : FireWeaponBase
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadTime;
    [SerializeField] private UnityEvent _shootEvent = new();

    private bool _isShooting;
    private IEnumerator _shooting;

    public override LootData lootData => _weaponData;

    public override int haveAmmo => 12;

    public override void StartAttacking()
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
            case (FireWeaponCartridgeType.automatic):
                while (_isShooting)
                {
                    Shoot();
                    yield return new WaitForSeconds(1f / _fireRate);
                }
                break;

            case (FireWeaponCartridgeType.semiAutomatic):
                Shoot();
                yield return null;
                break;
        }
    }

    public override void StopAttacking()
    {
        _isShooting = false;
        _shooting = null;
    }

    private void Shoot()
    {
        bool hited = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit);
        if (hited && hit.collider.TryGetComponent(out IEntity target))
        {
            target.TakeDamage(_weaponData.damage);
        }
        _shootEvent?.Invoke();
    }
}