using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueData dialogueData;
    public GameObject dialogueBox;
    public TMP_Text dialogueText, nameText;
    public CutsceneDialogueControl CutsceneDialogueControl;
    public CutsceneTrigger cutsceneTrigger;
    public GameObject player; 

    private int dialogueIndex;
    public bool isTyping, isDialogueActive;
    private PlayerController playerController;

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
        dialogueIndex = 0;
        isDialogueActive = true;
        dialogueBox.SetActive(true);
        var rb = playerController.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }
        playerController.forceIdle = true;

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
        nameText.text = dialogueData.dialogueLines[dialogueIndex].speakerName;
        foreach (char letter in dialogueData.dialogueLines[dialogueIndex].dialogueText)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }
        isTyping = false;
    }

    public void EndDialogue()
    {
        FindAnyObjectByType<CutsceneTrigger>().forceDisable = false;
        isDialogueActive = false;
        dialogueBox.SetActive(false);
        dialogueIndex = 0;
        dialogueText.text = "";
        nameText.text = "";
        playerController.forceIdle = false;
        if (dialogueData.playCutsceneAfter && cutsceneTrigger != null)
        {
            float yRot = player.transform.eulerAngles.y;

            if (Mathf.Abs(yRot - 180f) < 5f) 
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0); 
            }
            cutsceneTrigger.PlayCutscene(dialogueData.cutsceneIndex);

        }
        OnDialogueFinished();
    }

    public void OnDialogueFinished()
    {
        if (CutsceneDialogueControl != null)
        {
            CutsceneDialogueControl.ResumeCutscene();
        }
    }
}
