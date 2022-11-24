using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class InteractButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Interactor _interactor;

        [SerializeField] private Image _backgroundSpriteField;
        [SerializeField] private Sprite _disableSprite, _activateSprite;
        [SerializeField] private TextMeshProUGUI _promptLabel;

        private bool _canPressed;
        private Collider _currentColliderWithInteraction;
        private IInteractble _currentInteraction;

        private void Update()
        {

            bool haveInteraction = _interactor.CulculateNearestColliderInteraction(out Collider newColliderInteraction);

            if (haveInteraction && newColliderInteraction != _currentColliderWithInteraction)
            {
                _currentInteraction = newColliderInteraction.GetComponent<IInteractble>();
                _currentColliderWithInteraction = newColliderInteraction;
            }

            _canPressed = haveInteraction;
            _backgroundSpriteField.enabled = haveInteraction;
            _promptLabel.enabled = haveInteraction;

            if (haveInteraction)
            {
                _backgroundSpriteField.sprite = _activateSprite;
                _promptLabel.text = _currentInteraction.interactionPrompt;
            }
            else _backgroundSpriteField.sprite = _disableSprite;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_canPressed)
                _interactor.Interact(_currentInteraction);
        }
    }
}