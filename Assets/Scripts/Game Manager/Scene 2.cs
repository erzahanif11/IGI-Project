using UnityEngine;

public class Scene2 : MonoBehaviour
{
    public SceneInteractionManager sceneInteractionManager;
    private void Start()
    {
        sceneInteractionManager.LookAt();
    }
}
