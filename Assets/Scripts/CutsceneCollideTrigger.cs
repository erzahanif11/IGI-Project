using UnityEngine;

public class CutsceneCollideTrigger : MonoBehaviour
{
    public CutsceneTrigger CutsceneTrigger;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CutsceneTrigger.PlayCutscene(1);
            Destroy(gameObject);
        }
    }
}
