using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CanvasGroup canvasGroup;
    private CartaController cartaController;
    public GameObject actionMenuPrefab;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        cartaController = GameObject.FindGameObjectWithTag("Logic").GetComponent<CartaController>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!cartaController.isCardPanelActive && GameObject.FindGameObjectWithTag("ActionMenu") == null){
            canvasGroup.alpha = 0.6f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!cartaController.isCardPanelActive){
            canvasGroup.alpha = 1;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!cartaController.isCardPanelActive && GameObject.FindGameObjectWithTag("ActionMenu") == null)
        {
            Instantiate(actionMenuPrefab, transform.root);
        }
    }
}
