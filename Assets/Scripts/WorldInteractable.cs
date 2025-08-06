using UnityEngine;

public class WorldInteract : MonoBehaviour, IInteractable
{
    [TextArea(3, 10)] public string interactText;

    public void Interact(Transform interactor)
    {
        Debug.Log(interactText);
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
