using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueData dialogueData;
    public GameObject dialogueBox;
    public TMP_Text dialogueText, nameText;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
            NextLine();
        }
    }
    public void StartDialogue()
    {
        if (dialogueData == null || dialogueData.dialogueLines.Length == 0)
        {
            Debug.LogWarning("Dialogue data is not set or empty.");
            return;
        }
        dialogueIndex = 0;
        isDialogueActive = true;
        dialogueBox.SetActive(true);
        nameText.text = dialogueData.speakerName;
        StartCoroutine(TypeDialogue());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = dialogueData.dialogueLines[dialogueIndex];
            isTyping = false;
            return;
        }
        else if(dialogueIndex < dialogueData.dialogueLines.Length - 1)
        {
            dialogueIndex++;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            EndDialogue();
        }
    }
    IEnumerator TypeDialogue()
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }
        isTyping = false;
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        dialogueBox.SetActive(false);
        dialogueIndex = 0;
        dialogueText.text = "";
        nameText.text = "";
    }
}
