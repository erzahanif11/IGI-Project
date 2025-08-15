using Unity.Cinemachine;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    public bool interactedHP;
    public bool interactedLaptop;
    public bool interactedFigura;
    public DoorSceneLoader doorSceneLoader;

    public CutsceneTrigger cutsceneTrigger;
    public CinemachineCamera vCam1;
    public CinemachineCamera vCam2;
    private void Start()
    {
        doorSceneLoader.canLoadScene = false;
        vCam1.Priority = 12;
        vCam2.Priority = 10;
        cutsceneTrigger.PlayCutscene(0);
    }

    public void InteractHP()
    {
        interactedHP = true;
        checkAll();
    }
    public void InteractLaptop()
    {
        interactedLaptop = true;
        checkAll();
    }
    public void InteractFigura()
    {
        interactedFigura = true;
        checkAll();
    }

    void checkAll()
    {
        if (interactedHP && interactedLaptop && interactedFigura)
        {
            StartCoroutine(ketokPintu());
        }
    }

    System.Collections.IEnumerator ketokPintu()
    {
        vCam1.Priority = 10;
        vCam2.Priority = 12;
        //mulai sfx ketuk
        yield return new WaitForSeconds(3f);
        vCam2.Priority = 10;
        vCam1.Priority = 12;
        doorSceneLoader.canLoadScene = true;
    }
}
