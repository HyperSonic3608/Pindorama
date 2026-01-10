using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatLogic : MonoBehaviour
{
    [SerializeField] private SlotController slotController;
    [SerializeField] private CardController cardController;
    [SerializeField] private Dice dice;
    [SerializeField] private ActionMenu actionMenu;
    public GameObject attackAnimaitons;
    public Agente realizador;
    public Agente alvo;
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

    public void SetAgents()
    {
        foreach (Slot slot in slotController.GetSlots())
        {
            if (slot.currentCharacter.GetComponent<Character>() != null)
            {
                combate.aliados.Add(slot.currentCharacter.GetComponent<Character>().aliado);
            }
            else
            {
                combate.inimigos.Add(slot.currentCharacter.GetComponent<Enemy>().inimigo);
            }
        }
    }

    public void UpdateCombatPhase(int nextPhase)
    {
        combatPhase = nextPhase;
        if (nextPhase == 6)
        {
            realizador.SetJogouNesseTurno(true);
            combate.realizarAcao(realizador, alvo, dice.dado, actionMenu.lastActionType, actionMenu.lastButtonPressed);
            Debug.Log("Vida do realizador: " + realizador.vida + "\nVida do alvo: " + alvo.vida);
            if (combatPhase == -1)
            {
                EnemyAttack();
            }
        }
    }

    public int GetCombatPhase()
    {
        return combatPhase;
    }

    public void EnemyAttack()
    {
        Slot[] playerSlots = slotController.GetSlots(1);
        Slot[] enemySlots = slotController.GetSlots(2);
        do
        {
            int enemyRandom = Random.Range(0, enemySlots.Length);
            if (!enemySlots[enemyRandom].GetComponent<Slot>().currentCharacter.GetComponent<Enemy>().inimigo.jogouNesseTurno)
            {
                int playerRandom = Random.Range(0, playerSlots.Length);
                realizador = enemySlots[enemyRandom].GetComponent<Slot>().currentCharacter.GetComponent<Enemy>().inimigo;
                alvo = playerSlots[playerRandom].GetComponent<Slot>().currentCharacter.GetComponent<Character>().aliado;
                UpdateCombatPhase(4);
                dice.RollDice();
                return;
            }
        } while (true);
    }

    public void kill(bool isEnemy)
    {
        if (isEnemy)
        {
            enemyCount--;
            if (enemyCount == 0)
                SceneManager.LoadScene("MapaAldeiaYanomami");
        }
        else
        {
            playerCount--;
            if (playerCount == 0)
                SceneManager.LoadScene("Menu");
        }
    }
}
