using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;
    public MonoBehaviour playerMovement;
    public PlayableAsset[] playableAssets;
    private bool isCutscenePlaying = false;

    public void PlayCutscene(int index)
    {
        if (index < 0 || index >= playableAssets.Length) return;
        playerMovement.enabled = false;
        Input.ResetInputAxes();

        cutsceneDirector.playableAsset = playableAssets[index];
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
