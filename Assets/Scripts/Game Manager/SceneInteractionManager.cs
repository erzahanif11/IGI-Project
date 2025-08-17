using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class SceneInteractionManager : MonoBehaviour
{
    [Header("Required Interactions")]
    public List<string> requiredObjects;
    private HashSet<string> interactedObjects = new HashSet<string>();

    [Header("Scene Settings")]
    public DoorSceneLoader doorSceneLoader;
    public CutsceneTrigger cutsceneTrigger;
    public CinemachineCamera vCam1;
    public CinemachineCamera vCam2;

    private void Start()
    {
        doorSceneLoader.canLoadScene = false;

        vCam1.Priority = 12;
        vCam2.Priority = 10;
    }

    // Dipanggil oleh object interaktif
    public void RegisterInteraction(string objectName)
    {
        if (!interactedObjects.Contains(objectName))
        {
            interactedObjects.Add(objectName);
            CheckAllInteractions();
        }
    }

    private void CheckAllInteractions()
    {
        if (interactedObjects.Count >= requiredObjects.Count &&
            requiredObjects.TrueForAll(obj => interactedObjects.Contains(obj)))
        {
            StartCoroutine(KetokPintu());
        }
    }

    private System.Collections.IEnumerator KetokPintu()
    {
        vCam1.Priority = 10;
        vCam2.Priority = 12;
        yield return new WaitForSeconds(3f);
        vCam2.Priority = 10;
        vCam1.Priority = 12;
        doorSceneLoader.canLoadScene = true;
    }

    public void LookAt()
    {
        StartCoroutine(KetokPintu());
    }
}
