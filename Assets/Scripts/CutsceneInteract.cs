using UnityEngine;

public class CutsceneInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private CutsceneTrigger cutsceneTrigger;
    [SerializeField] private int cutsceneIndex;
    [SerializeField] private GameObject player;
    public void Interact(Transform interactor)
    {
        if (cutsceneTrigger != null)
        {
            if(player.transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            cutsceneTrigger.PlayCutscene(cutsceneIndex);
        }
        else
        {
            Debug.LogWarning("CutsceneTrigger is not assigned in CutsceneInteract.");
        }
    }
}
