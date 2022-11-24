using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private ViewRotater _viewRotater;

    private Vector2 _previousPoint;
    private Vector2 _startPoint;

    private Vector2 _screenSize { get { return Vector2.right * Screen.width + Vector2.up * Screen.height; } }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPoint = eventData.position;
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 tapDirection = (eventData.position - _startPoint) / _screenSize;
        Vector2 directrion = tapDirection - _previousPoint;

        _viewRotater.Rotate(Vector2.up * -directrion.y + Vector2.right * directrion.x);
        _previousPoint = tapDirection;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _previousPoint = Vector2.zero;
    }
}
