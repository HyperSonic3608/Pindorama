using UnityEngine;

public class CombatLogic : MonoBehaviour
{
    [SerializeField] private SlotController slotController;
    [SerializeField] private CardController cardController;
    private int combatPhase;
    public int playerCount;
    public int enemyCount;
    public int cardCount;
    void Start()
    {
        slotController.SlotCreator(playerCount, enemyCount);
        cardController.CardCreator(cardCount);
        combatPhase = 0;
    }

    public void UpdateCombatPhase(int nextPhase)
    {
        combatPhase = nextPhase;
    }

    public int GetCombatPhase()
    {
        return combatPhase;
    }
}
