using UnityEngine;
using System.Collections;

public class WorldInteractable : MonoBehaviour, IInteractable
{
    public DialogueManager dialogueManager;
    public DialogueData dialogueData;
    public SceneInteractionManager sceneManager;
    public string objectName;
    public void Interact(Transform interactor)
    {
        if(dialogueData != null && dialogueManager != null)
        {
            dialogueManager.dialogueData = dialogueData;
            dialogueManager.StartDialogue();
            StartCoroutine(WaitUntilDialogueFinished());
        }
        else
        {
            Debug.LogWarning("DialogueData or DialogueManager is not set.");
        }
    }

    IEnumerator WaitUntilDialogueFinished()
    {
        yield return new WaitUntil(() => !dialogueManager.isDialogueActive);
        sceneManager.RegisterInteraction(objectName);
    }
}
