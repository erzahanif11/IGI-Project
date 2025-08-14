using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutsceneDialogueControl : MonoBehaviour, INotificationReceiver
{
    public PlayableDirector director;
    public DialogueManager dialogueManager; // script dialog kamu
    public DialogueData dialogueData; // data dialog yang akan digunakan

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is DialogueSignal signal)
        {
            // Tampilkan dialog
            dialogueManager.dialogueData = signal.dialogueData; // Set data dialog
            dialogueManager.StartDialogue();
            Debug.Log("Signal Received");

            // Pause Timeline
            director.playableGraph.GetRootPlayable(0).SetSpeed(0);

        }
    }

    public void ResumeCutscene()
    {
        if(director != null && director.playableGraph.IsValid())
        {
            // Resume Timeline
            director.playableGraph.GetRootPlayable(0).SetSpeed(1);
        }
    }

}
