using UnityEngine;
using UnityEngine.EventSystems;

public class Carta : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        // Logic for when dragging starts
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        // Logic for dragging the card
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // Logic for when dragging ends
    }
}
