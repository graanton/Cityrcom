using System;
using System.Collections;
using UnityEngine;

public class WeaponVisualizer : MonoBehaviour
{
    [SerializeField] private GunShooter _gunShooter;
    [SerializeField] private Transform _visualizeParent;

    private WeaponBase _visualizedWeapon;

    private void Awake()
    {
        _gunShooter.weaponSettedEvent.AddListener(OnWeaponSetted);
    }

    private void OnWeaponSetted(WeaponBase weapon)
    {
        if(_visualizedWeapon != null)
        {
            Destroy(_visualizedWeapon.gameObject);
        }

        _visualizedWeapon = Instantiate(weapon, _visualizeParent);
    }
}