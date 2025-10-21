using UnityEngine;

public class CombatLogic : MonoBehaviour
{
    [SerializeField] private SlotController slotController;
    [SerializeField] private CardController cardController;
    public Character character;
    public Enemy enemy;
    private Combate combate;
    private int combatPhase
    {
        get { return combate.turno; }
        set { combate.turno = value; }
    }
    public int playerCount;
    public int enemyCount;
    public int cardCount;
    void Start()
    {
        combate = new Combate();
        slotController.SlotCreator(playerCount, enemyCount);
        cardController.CardCreator(cardCount);
        combatPhase = 0;
    }

    public void UpdateCombatPhase(int nextPhase)
    {
        combatPhase = nextPhase;
        if(nextPhase == 5)
        {
            combate.aliado = character.aliado;
            combate.inimigo = enemy.inimigo;
        }
    }

    public int GetCombatPhase()
    {
        return combatPhase;
    }
}
