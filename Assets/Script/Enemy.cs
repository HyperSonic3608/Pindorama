using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CanvasGroup canvasGroup;
    private ActionMenu actionMenu;
    private Dado dado;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        actionMenu = GameObject.FindGameObjectWithTag("ActionMenu").GetComponent<ActionMenu>();
        dado = GameObject.FindGameObjectWithTag("Dice").GetComponent<Dado>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(actionMenu);
        if (actionMenu.lastButtonPressed != null && !actionMenu.isEnemySelected)
        {
            canvasGroup.alpha = 0.6f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(actionMenu.lastButtonPressed != null){
            canvasGroup.alpha = 1;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (actionMenu.lastButtonPressed != null && !actionMenu.isEnemySelected)
        {
            actionMenu.isEnemySelected = true;
            dado.RollDice();
        }
    }
}
