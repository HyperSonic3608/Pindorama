
using UnityEngine;
using UnityEngine.EventSystems;

public class Carta : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;
    public GameObject characterPrefab;
    private Animator animator;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        animator = GetComponent<Animator>();
        animator.SetFloat("CardRarity", Random.Range(0,3));
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
                dropSlot.currentCharacter = Instantiate(characterPrefab, dropSlot.transform);
                dropSlot.currentCharacter.name = "Character " + dropSlot.transform.childCount;
                dropSlot.currentCharacter.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 40);
                gameObject.SetActive(false);
            }
        }

        transform.SetParent(originalParent);
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
