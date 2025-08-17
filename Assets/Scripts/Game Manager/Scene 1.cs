using UnityEngine;

public class Scene1 : MonoBehaviour
{
    [SerializeField] private CutsceneTrigger cutsceneTrigger;
    void Start()
    {
        cutsceneTrigger.PlayCutscene(0);
    }
}
