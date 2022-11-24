using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class GunShootUIInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GunShooter _gunShooter;
    [SerializeField] private ScreenInput _screenInput;

    public void OnPointerDown(PointerEventData eventData)
    {
        _gunShooter.StartShootingFromEquippedWeapon();
        _screenInput.OnPointerDown(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _screenInput.OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _gunShooter.StopShootingWithEquippedWeapon();
        _screenInput.OnPointerUp(eventData);
    }
}
