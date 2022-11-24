using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractble
{
    public string interactionPrompt => "Chest";
    public bool canInteraction => true;

    public List<LootBase> content;

    public void Interact(Interactor interactor)
    {
        if (interactor.TryGetComponent(out ChestHandler chestHandler))
        {
            chestHandler.Open(this);
        }
    }
}