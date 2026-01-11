using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDialogueScript : MonoBehaviour, IInteractable
{
    public Texts dialogueData;
    public TMP_Text dialogueText;
    private int dialogueIndex;
    private bool isTyping;
    [SerializeField] bool condicaoFuncionamento;
    [SerializeField] string mapa;
    [SerializeField] bool switchMap;

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
            StopDialogue();
        }
    }

    public void StopDialogue()
    {
        StopAllCoroutines();
        dialogueText.SetText("");

        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        playerCanMove = true;

        if (switchMap == true)
        {
            SceneManager.LoadScene(mapa);
        }
    }
    void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        dialogueIndex = 0;

        if (condicaoFuncionamento == false)
        {
            playerCanMove = true;
        }
        else
        {
            playerCanMove = true;
        }
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
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
        else if (++dialogueIndex < dialogueData.dialogueLines.Length)
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
        return true;
    }

    public void Start()
    {
        if (condicaoFuncionamento == true)
        {
            Interact();
        }
    }
}