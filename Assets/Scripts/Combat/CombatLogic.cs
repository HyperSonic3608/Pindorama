using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatLogic : MonoBehaviour
{
    [SerializeField] private SlotController slotController;
    [SerializeField] private CardController cardController;
    [SerializeField] private Dice dice;
    [SerializeField] private ActionMenu actionMenu;
    public GameObject attackAnimaitons;
    public Character character;
    public Enemy enemy;
    private Combate combate;
    private int combatPhase
    {
        get { return combate.turno; }
        set { combate.defineTurno(value); }
    }
    public int playerCount;
    public int enemyCount;
    public int cardCount;
    void Start()
    {
        slotController.SlotCreator(playerCount, enemyCount);
        cardController.CardCreator(cardCount);
        combate = new Combate();
        combatPhase = 0;
    }

    public void UpdateCombatPhase(int nextPhase)
    {
        combatPhase = nextPhase;
        if(nextPhase == 6)
        {
            combate.realizarAcao(character.aliado, enemy.inimigo, dice.dado, actionMenu.lastActionType, actionMenu.lastButtonPressed);
            Debug.Log("Vida do aliado: " + character.aliado.vida + "\nVida do inimigo: " + enemy.inimigo.vida);
        }
    }

    public int GetCombatPhase()
    {
        return combatPhase;
    }

    public void kill(){
        enemyCount--;
        if(enemyCount == 0)
        SceneManager.LoadScene("MapaAldeiaYanomami");
    }
}
