using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject cutscene;
    public PlayableDirector cutsceneDirector;
    public MonoBehaviour playerMovement;
    public MonoBehaviour playerInteract;
    public PlayableAsset[] playableAssets;
    private bool isCutscenePlaying = false;
    public bool forceDisable = false;

    private void Awake()
    {
        cutscene.SetActive(false);
    }
    private void Update()
    {
        if (isCutscenePlaying || forceDisable)
        {
            playerMovement.enabled = false;
            playerInteract.enabled = false;
        }
        else{
            playerMovement.enabled = true;
            playerInteract.enabled = true;
        }
    }
    public void PlayCutscene(int index)
    {
        cutscene.SetActive(true);
        if (index < 0 || index >= playableAssets.Length) return;
        Input.ResetInputAxes();

        cutsceneDirector.playableAsset = playableAssets[index];
        cutsceneDirector.Play();
        isCutscenePlaying = true;

        cutsceneDirector.stopped += OnCutsceneEnd;
    }

    private void OnCutsceneEnd(PlayableDirector director)
    {
        isCutscenePlaying = false;

        cutsceneDirector.stopped -= OnCutsceneEnd;
        cutscene.SetActive(false);
    }
}
