using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCDialogueScript : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;
    public TMP_Text dialogueText;
    private int dialogueIndex;
    private bool isTyping;


    public GameObject dialoguePanel;

    private bool isDialogueActive;

    private bool playerCanMove = true;

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        if (dialogueData == null)
        {
            return;
        }


        if (!isDialogueActive)
        {
            StartDialogue();
            
        }
        else
        {
            NextLine();
            //StopDialogue();
        }
    }

    public void StopDialogue()
    {
        StopAllCoroutines();
        dialogueText.SetText("");

        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        playerCanMove = true;
    }
    void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        playerCanMove = false;
        dialogueIndex = 0;

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach(char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if(dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if(++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            StopDialogue();
        }
    }

    public bool GetPlayerCanMove()
    {
        return this.playerCanMove;
    }
}