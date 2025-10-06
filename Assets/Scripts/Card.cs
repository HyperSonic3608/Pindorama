
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Carta : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;
    public GameObject characterPrefab;
    private GameObject character;

    void Start()
    {
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

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>();
        if (dropSlot != null)
        {
            if (dropSlot.currentCharacter == null)
            {
                character.transform.SetParent(dropSlot.transform);
                character.name = "Character " + dropSlot.transform.childCount;
                character.transform.localScale = Vector3.one;
                character.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 78f);
                character.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
                character.GetComponent<RectTransform>().anchoredPosition = new Vector2(18.5f, 150);
                dropSlot.currentCharacter = character;
                gameObject.SetActive(false);
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
