using UnityEngine;

public class Scene2_1 : MonoBehaviour
{
    public SceneInteractionManager sceneInteractionManager;
    private void Start()
    {
        sceneInteractionManager.LookAt();
    }
}
