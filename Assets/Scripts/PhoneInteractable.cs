using System.Collections;
using UnityEngine;

public class PhoneInteractable : MonoBehaviour,IInteractable
{
    public PhoneManager phoneManager;
    public DialogueData dialogueData;
    public SceneInteractionManager sceneManager;
    public void Interact(Transform interactor)
    {
        if (dialogueData != null && phoneManager != null)
        {
            phoneManager.dialogueData = dialogueData;
            phoneManager.StartDialogue();
            StartCoroutine(WaitUntilDialogueFinished());
        }
        else
        {
            Debug.LogWarning("DialogueData or DialogueManager is not set.");
        }
    }

    IEnumerator WaitUntilDialogueFinished()
    {
        yield return new WaitUntil(() => !phoneManager.isDialogueActive);
        sceneManager.RegisterInteraction(gameObject.name);
    }
}
