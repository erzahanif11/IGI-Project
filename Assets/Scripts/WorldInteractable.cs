using UnityEngine;

public class WorldInteractable : MonoBehaviour, IInteractable
{
    public DialogueManager dialogueManager;
    public DialogueData dialogueData;
    public void Interact(Transform interactor)
    {
        if(dialogueData != null && dialogueManager != null)
        {
            dialogueManager.dialogueData = dialogueData;
            dialogueManager.StartDialogue();
        }
        else
        {
            Debug.LogWarning("DialogueData or DialogueManager is not set.");
        }
    }
}
