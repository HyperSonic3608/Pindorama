using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CanvasGroup canvasGroup;
    private CombatLogic combatLogic;
    private ActionMenu actionMenu;
    private Dado dado;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        combatLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<CombatLogic>();
        actionMenu = GameObject.FindGameObjectWithTag("ActionMenu").GetComponent<ActionMenu>();
        dado = GameObject.FindGameObjectWithTag("Dice").GetComponent<Dado>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (combatLogic.GetCombatPhase() == 3)
        {
            canvasGroup.alpha = 0.6f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (combatLogic.GetCombatPhase() == 3)
        {
            combatLogic.UpdateCombatPhase(4);
            actionMenu.Close();
            dado.RollDice();
        }
    }
}
