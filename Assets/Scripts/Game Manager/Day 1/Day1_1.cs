using UnityEngine;

public class Day1_1 : MonoBehaviour
{
    public CutsceneTrigger cutsceneTrigger;
    private void Start()
    {
        cutsceneTrigger.PlayCutscene(0);
    }
}
