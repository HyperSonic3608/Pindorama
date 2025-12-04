using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public Inimigo inimigo;
    private CanvasGroup canvasGroup;
    private CombatLogic combatLogic;
    private ActionMenu actionMenu;
    private Dice dado;
    private Vector3 vector3;

    void Start()
    {
        inimigo = new Inimigo("Cobra", Personagem.Classe.Animal, Personagem.Tipo.Cobra, new Arma(Arma.Tipo.Físico, Item.Raridade.Normal));
        canvasGroup = GetComponent<CanvasGroup>();
        combatLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<CombatLogic>();
        actionMenu = GameObject.FindGameObjectWithTag("ActionMenu").GetComponent<ActionMenu>();
        dado = GameObject.FindGameObjectWithTag("Dice").GetComponent<Dice>();
        vector3 = new Vector3();
    }

    void Update()
    {
        vector3.Set(Pointer.current.position.ReadValue().x, Pointer.current.position.ReadValue().y, 1);
        if (combatLogic.GetCombatPhase() == 3 && GetComponent<BoxCollider2D>().bounds.Contains(vector3))
        {
            canvasGroup.alpha = 0.6f;
            if (Pointer.current.press.isPressed)
            {
                combatLogic.enemy = this;
                combatLogic.UpdateCombatPhase(4);
                actionMenu.Close();
                dado.RollDice();
            }
        }
        else
        {
            canvasGroup.alpha = 1;
        }
        if (inimigo.vida == 0)
        {
            gameObject.SetActive(false);
            combatLogic.kill();
        }
    }
}
