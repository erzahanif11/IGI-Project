using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneLoader : MonoBehaviour, IInteractable
{
    [SerializeField] private SceneReference[] sceneLoad;
    [SerializeField] private int sceneIndex = 0;
    public void Interact(Transform interactor)
    {
        if (sceneLoad != null && sceneLoad.Length > 0)
        {
            if (sceneIndex >= 0 && sceneIndex < sceneLoad.Length && sceneLoad[sceneIndex] != null)
            {
                SceneManager.LoadScene(sceneLoad[sceneIndex].SceneName);
            }
            else
            {
                Debug.LogWarning("Scene index is out of bounds or scene is null.");
            }
        }
        else
        {
            Debug.LogWarning("No scenes to load.");
        }
    }
}

[System.Serializable]
public class SceneReference
{
    public UnityEngine.Object scenes;
    public string SceneName
    {
        get
        {
            return scenes != null ? scenes.name : string.Empty;
        }
    }
}
