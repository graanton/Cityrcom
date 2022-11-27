using System;
using System.Collections;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private GunShooter _gunShooter;
    [SerializeField] private Transform _leftHand, _rightHand;

    private Transform _leftHandTarget, _rightHandTarget;

    private void Awake()
    {
        _gunShooter.weaponSettedEvent.AddListener(OnWeaponSetted);
    }

    private void OnWeaponSetted(WeaponBase weapon)
    {
        _rightHandTarget = weapon.rightHandPoint;
        _leftHandTarget = weapon.leftHandPoint;
        weapon.transform.position = weapon.localPoint.position;
    }

    private void Update()
    {
        if (_leftHandTarget != null)
        {
            _leftHand.position = _leftHandTarget.position;
        }
        if (_rightHandTarget != null)
        {
            _rightHand.position = _rightHandTarget.position;
        }
    }
}
