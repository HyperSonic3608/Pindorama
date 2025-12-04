using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    [SerializeField] private GameObject playerHorizontalPanel;
    [SerializeField] private GameObject enemyHorizontalPanel;
    [SerializeField] private GameObject verticalPrefab;
    [SerializeField] private GameObject slotPlayerPrefab;
    [SerializeField] private GameObject slotEnemyPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    private int slotPlayerCount;
    private int slotEnemyCount;
    private Slot[] playerSlots;
    private Slot[] enemySlots;

    private void SlotCreator(int i, bool isPlayer)
    {
        GameObject verticalSlot = Instantiate(verticalPrefab, isPlayer ? playerHorizontalPanel.transform : enemyHorizontalPanel.transform);
        verticalSlot.name = "VerticalPanel " + (i / 2 + 1);
        for (int j = 0; j < 2; j++)
        {
            if (i + j >= (isPlayer ? slotPlayerCount : slotEnemyCount)) break;
            GameObject slot = Instantiate(isPlayer ? slotPlayerPrefab : slotEnemyPrefab, verticalSlot.transform);
            slot.name = "Slot " + (i + j + 1);
            if (!isPlayer)
            {
                GameObject enemy = Instantiate(EnemyPrefab, slot.transform);
                enemy.name = "Enemy " + (i + j + 1);
                enemy.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 30);
                slot.GetComponent<Slot>().currentCharacter = enemy;
                enemySlots[i + j] = slot.GetComponent<Slot>();
            }
            else
            {
                playerSlots[i + j] = slot.GetComponent<Slot>();
            }
        }
    }

    public void SlotCreator(int slotPlayerCount, int slotEnemyCount)
    {
        playerSlots = new Slot[slotPlayerCount];
        enemySlots = new Slot[slotEnemyCount];
        this.slotPlayerCount = slotPlayerCount;
        this.slotEnemyCount = slotEnemyCount;
        for (int i = 0; i < slotPlayerCount; i += 2)
        {
            SlotCreator(i, true);
        }

        for (int i = 0; i < slotEnemyCount; i += 2)
        {
            SlotCreator(i, false);
        }
    }

    public Slot[] GetSlots()
    {
        Slot[] slots = new Slot[slotPlayerCount + slotEnemyCount];
        
        for (int i = 0; i < slotPlayerCount; i++)
        {
            slots[i] = playerSlots[i];
        }
        for (int i = 0; i < slotEnemyCount; i++)
        {
            slots[i + slotPlayerCount] = enemySlots[i];
        }

        return slots;
    }
}
