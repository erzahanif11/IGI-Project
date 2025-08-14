using UnityEngine;

public class CutsceneInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private CutsceneTrigger cutsceneTrigger;
    [SerializeField] private int cutsceneIndex;
    public void Interact(Transform interactor)
    {
        if (cutsceneTrigger != null)
        {
            cutsceneTrigger.PlayCutscene(cutsceneIndex);
        }
        else
        {
            Debug.LogWarning("CutsceneTrigger is not assigned in CutsceneInteract.");
        }
    }
}
