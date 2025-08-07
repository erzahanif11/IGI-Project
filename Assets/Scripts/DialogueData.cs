using UnityEngine;

[CreateAssetMenu(fileName = "newDialogue", menuName = "ScriptableObjects/DialogueData")]
public class DialogueData : ScriptableObject
{
    public string speakerName;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;
}
