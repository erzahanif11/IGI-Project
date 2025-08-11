using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    [TextArea(2, 5)]
    public string dialogueText;
}

[CreateAssetMenu(fileName = "newDialogue", menuName = "ScriptableObjects/DialogueData")]
public class DialogueData : ScriptableObject
{
    public DialogueLine[] dialogueLines;
    public float typingSpeed = 0.05f;
}
