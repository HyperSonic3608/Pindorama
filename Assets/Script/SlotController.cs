using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public GameObject playerHorizontalPanel;
    public GameObject enemyHorizontalPanel;
    public GameObject verticalPrefab;
    public GameObject slotPlayerPrefab;
    public GameObject slotEnemyPrefab;
    public GameObject EnemyPrefab;
    public int slotPlayerCount;
    public int slotEnemyCount;

    void SlotCreator(int i, bool isPlayer)
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
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < slotPlayerCount; i += 2)
        {
            SlotCreator(i, true);
        }

        for (int i = 0; i < slotEnemyCount; i += 2)
        {
            SlotCreator(i, false);
        }
    }
}
