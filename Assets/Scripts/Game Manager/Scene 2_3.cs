using Unity.Cinemachine;
using UnityEngine;

public class Scene2_3 : MonoBehaviour
{
    public CutsceneTrigger CutsceneTrigger;
    private void Start()
    {
        CutsceneTrigger.PlayCutscene(0);
    }
}
