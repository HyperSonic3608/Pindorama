using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CanvasGroup canvasGroup;
    private CartaController cartaController;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        cartaController = GameObject.FindGameObjectWithTag("Logic").GetComponent<CartaController>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!cartaController.isCardPanelActive){
            canvasGroup.alpha = 0.6f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!cartaController.isCardPanelActive){
            canvasGroup.alpha = 1;
        }
    }
}
