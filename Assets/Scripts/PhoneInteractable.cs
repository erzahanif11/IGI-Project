using UnityEngine;

public class PhoneInteractable : MonoBehaviour,IInteractable
{
    public PhoneManager phoneManager;
    public DialogueData dialogueData;
    public void Interact(Transform interactor)
    {
        if (dialogueData != null && phoneManager != null)
        {
            phoneManager.dialogueData = dialogueData;
            phoneManager.StartDialogue();
        }
        else
        {
            Debug.LogWarning("DialogueData or DialogueManager is not set.");
        }
    }
}
