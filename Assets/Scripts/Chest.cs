using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractble
{
    [SerializeField] private string _prompt = "Chest";

    public string interactionPrompt => _prompt;
    public bool canInteraction => true;

    public List<LootBase> content = new();

    public void Interact(Interactor interactor)
    {
        if (interactor.TryGetComponent(out ChestHandler chestHandler))
        {
            chestHandler.Open(this);
        }
    }

}