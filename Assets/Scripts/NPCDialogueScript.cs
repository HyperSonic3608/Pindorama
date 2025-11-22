using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueScript : MonoBehaviour, IInteractable
{
    public GameObject dialoguePanel;

    private bool isDialogueActive;

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
    }
    void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
    }
}