using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject animationObject;
    public GameObject animationBigObject;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private AnimatorController[] animator;
    public Aliado aliado { get; private set; }
    private bool isBruto;
    private CombatLogic combatLogic;
    private GameObject actionMenu;
    public Image image { get; private set; }
    public int rarity { get; private set; }

    void Start()
    {
        aliado = new Aliado("Indígena", Personagem.Classe.Indigena, Personagem.Tipo.Mediano, new Arma(Arma.Tipo.Faca, (Item.Raridade)Random.Range(0,3)));
        rarity = (int)aliado.arma.raridade;
        transform.parent.GetComponent<Animator>().SetFloat("CardRarity", rarity);
        canvasGroup = GetComponent<CanvasGroup>();
        combatLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<CombatLogic>();
        actionMenu = GameObject.FindGameObjectWithTag("ActionMenu");
        SetAnimator(aliado.tipo);
    }

    void SetAnimator(Personagem.Tipo tipo)
    {
        isBruto = tipo == Personagem.Tipo.Bruto;
        animationBigObject.SetActive(isBruto);
        animationObject.SetActive(!isBruto);
        image = isBruto ? animationBigObject.GetComponent<Image>() : animationObject.GetComponent<Image>();
        if (!isBruto)
        {
            if (tipo == Personagem.Tipo.Pequeno)
            {
                animationObject.GetComponent<Animator>().runtimeAnimatorController = animator[0];
            }
            else
            {
                animationObject.GetComponent<Animator>().runtimeAnimatorController = animator[1];
            }
        }
    }

    void Update()
    {
        if (combatLogic.GetCombatPhase() == 1 && GetComponent<BoxCollider2D>().bounds.Contains(Pointer.current.position.ReadValue()))
        {
            canvasGroup.alpha = 0.6f;
            if (Pointer.current.press.isPressed)
            {
                combatLogic.character = this;
                actionMenu.transform.SetPositionAndRotation(new Vector3(actionMenu.transform.position.x * -1, actionMenu.transform.position.y, actionMenu.transform.position.z), actionMenu.transform.rotation);
                actionMenu.GetComponent<ActionMenu>().character = gameObject;
                actionMenu.GetComponent<ActionMenu>().UpdateImage();
                combatLogic.UpdateCombatPhase(2);
            }
        }
        else if (combatLogic.GetCombatPhase() < 2 || combatLogic.GetCombatPhase() > 3)
        {
            canvasGroup.alpha = 1;
        }
    }
}
