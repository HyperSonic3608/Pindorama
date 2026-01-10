using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatLogic : MonoBehaviour
{
    [SerializeField] private SlotController slotController;
    [SerializeField] private CardController cardController;
    [SerializeField] private Dice dice;
    public GameObject attackAnimaitons;
    private AttackController attackController;
    public Agente realizador;
    public Agente alvo;
    private Combate combate;
    private int combatPhase
    {
        get { return combate.turno; }
        set { combate.defineTurno(value); }
    }
    public int lastActionType
    {
        get { return combate.ultimaAcao; }
        set { combate.setUltimaAcao(value); }
    }
    public int lastButtonPressed
    {
        get { return combate.ultimaOrdem; }
        set { combate.setUltimaOrdem(value); }
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
        attackController = attackAnimaitons.GetComponentInChildren<AttackController>();
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

    public void setAction(int type, int option)
    {
        lastActionType = type;
        lastButtonPressed = option;
    }

    public void UpdateCombatPhase(int nextPhase)
    {
        combatPhase = nextPhase;
        if (nextPhase == 5)
        {
            realizador.SetJogouNesseTurno(true);
            combate.realizarAcao(realizador, alvo, dice.dado);
            Debug.Log("Vida do realizador: " + realizador.vida + "\nVida do alvo: " + alvo.vida);
            attackController.Show();
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
