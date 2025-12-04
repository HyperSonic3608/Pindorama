
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private SlotController slotController;
    Transform originalParent;
    CanvasGroup canvasGroup;
    public GameObject characterPrefab;
    private GameObject character;

    void Start()
    {
        slotController = GameObject.FindGameObjectWithTag("Logic").GetComponent<SlotController>();
        canvasGroup = GetComponent<CanvasGroup>();
        setCharacter();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        foreach (Slot slot in slotController.GetSlots())
        {
            if (slot.transform.GetComponent<BoxCollider2D>().bounds.Contains(eventData.position))
            {
                if (slot.currentCharacter == null)
                {
                    character.transform.SetParent(slot.transform);
                    character.name = "Character " + slot.transform.childCount;
                    character.transform.localScale = Vector3.one;
                    character.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 78f);
                    character.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
                    character.GetComponent<RectTransform>().anchoredPosition = new Vector2(18.5f, 150);
                    slot.currentCharacter = character;
                    gameObject.SetActive(false);
                }
            }
        }

        transform.SetParent(originalParent);
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    void setCharacter()
    {
        character = Instantiate(characterPrefab, transform);
        character.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 90f);
        character.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 162f);
        character.GetComponent<RectTransform>().anchoredPosition = new Vector2(140, 255);
    }
}
