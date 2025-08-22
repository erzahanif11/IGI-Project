using UnityEngine;

public class Scene3_2 : MonoBehaviour
{
    public SceneInteractionManager sceneInteractionManager;
    public CutsceneTrigger cutsceneTrigger;
    private void Start()
    {
        sceneInteractionManager.LookAt();
        cutsceneTrigger.PlayCutscene(0);
    }
}
