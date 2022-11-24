public interface IInteractble
{
    public string interactionPrompt { get; }
    public bool canInteraction { get; }
    public void Interact(Interactor interactor);
}

