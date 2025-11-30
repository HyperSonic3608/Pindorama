using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueScript : MonoBehaviour, IInteractable
{
    public GameObject dialoguePanel;

    private bool isDialogueActive;

    private bool playerCanMove = true;

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
            if (isDialogueActive)
            {
                StopDialogue();
            }
            else
            {
                StartDialogue();
            }

    }

    void StopDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        playerCanMove = true;
    }
    void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        playerCanMove = false;
    }

    public bool GetPlayerCanMove()
    {
        return this.playerCanMove;
    }
}