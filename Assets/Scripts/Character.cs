using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CanvasGroup canvasGroup;
    private CombatLogic combatLogic;
    private GameObject actionMenu;
    private int cardRarity;

    public int CardRarity { get => cardRarity;}

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        combatLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<CombatLogic>();
        actionMenu = GameObject.FindGameObjectWithTag("ActionMenu");
        cardRarity = Random.Range(0,3);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (combatLogic.GetCombatPhase() == 1)
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
        if (combatLogic.GetCombatPhase() == 1)
        {
            actionMenu.transform.SetPositionAndRotation(new Vector3(actionMenu.transform.position.x * -1, actionMenu.transform.position.y, actionMenu.transform.position.z), actionMenu.transform.rotation);
            actionMenu.GetComponent<ActionMenu>().character = gameObject;
            actionMenu.GetComponent<ActionMenu>().UpdateImage();
            combatLogic.UpdateCombatPhase(2);
        }
    }
}
