using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Character : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image charactherImage;
    private CanvasGroup canvasGroup;
    private CombatLogic combatLogic;
    private GameObject actionMenu;
    private int rarity;
    public int CharacterRarity { get => rarity;}

    void Start()
    {
        rarity = Random.Range(0,3);
        transform.parent.GetComponent<Animator>().SetFloat("CardRarity", rarity);
        canvasGroup = GetComponent<CanvasGroup>();
        combatLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<CombatLogic>();
        actionMenu = GameObject.FindGameObjectWithTag("ActionMenu");
    }

    void Update(){
        transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, charactherImage.sprite.rect.width*5.2f);
        transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, charactherImage.sprite.rect.height*5.2f);
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
