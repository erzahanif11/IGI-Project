using UnityEngine;
using UnityEngine.Playables;

public class Scene2_2 : MonoBehaviour
{
    public CutsceneTrigger cutsceneTrigger;
    public DoorSceneLoader doorSceneLoader;

    void Start()
    {
        cutsceneTrigger.PlayCutscene(0);
        doorSceneLoader.canLoadScene = true;
    }
}
