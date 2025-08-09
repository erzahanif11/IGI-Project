using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;
    public MonoBehaviour playerMovement;
    private bool isCutscenePlaying = false;

    public void PlayCutscene()
    {
        playerMovement.enabled = false;
        Input.ResetInputAxes();

        cutsceneDirector.Play();
        isCutscenePlaying = true;

        cutsceneDirector.stopped += OnCutsceneEnd;
    }

    private void OnCutsceneEnd(PlayableDirector director)
    {
        playerMovement.enabled = true;
        isCutscenePlaying = false;

        cutsceneDirector.stopped -= OnCutsceneEnd;
    }
}
