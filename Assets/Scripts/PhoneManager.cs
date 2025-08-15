using TMPro;
using UnityEngine;
using System.Collections;

public class PhoneManager : MonoBehaviour
{
    public DialogueData dialogueData;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;

    private int dialogueIndex;
    public bool isTyping, isDialogueActive;
    private PlayerController playerController;
    private bool isInteracted = false;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }
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
        FindAnyObjectByType<CutsceneTrigger>().forceDisable = true;
        isDialogueActive = true;
        dialogueBox.SetActive(true);
        dialoguePanel.SetActive(false);
        if (isInteracted)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = dialogueData.dialogueLines[1].dialogueText;
            return;
        }
        dialogueIndex = 0;
        playerController.enabled = false;
        StartCoroutine(TypeDialogue());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = dialogueData.dialogueLines[dialogueIndex].dialogueText;
            isTyping = false;
            return;
        }
        else if (dialogueIndex < dialogueData.dialogueLines.Length - 1)
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
        foreach (char letter in dialogueData.dialogueLines[dialogueIndex].dialogueText)
        {
            if(dialogueIndex > 0)
            {
                dialoguePanel.SetActive(true);
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }
        isTyping = false;
    }

    public void EndDialogue()
    {
        FindAnyObjectByType<CutsceneTrigger>().forceDisable = false;
        isInteracted = true;
        dialogueBox.SetActive(false);
        isDialogueActive = false;
        playerController.enabled = true;
    }
}
