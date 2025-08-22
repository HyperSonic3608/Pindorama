using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CanvasGroup canvasGroup;
    private CartaController cartaController;
    private GameObject actionMenu;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        cartaController = GameObject.FindGameObjectWithTag("Logic").GetComponent<CartaController>();
        actionMenu = GameObject.FindGameObjectWithTag("ActionMenu");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!cartaController.isCardPanelActive && actionMenu.transform.position.x < 0)
        {
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
        if (!cartaController.isCardPanelActive && actionMenu.transform.position.x < 0)
        {
            actionMenu.transform.SetPositionAndRotation(new Vector3(actionMenu.transform.position.x * -1, actionMenu.transform.position.y, actionMenu.transform.position.z), actionMenu.transform.rotation);
            actionMenu.GetComponent<ActionMenu>().character = gameObject;
            actionMenu.GetComponent<ActionMenu>().UpdateImage();
        }
    }
}
