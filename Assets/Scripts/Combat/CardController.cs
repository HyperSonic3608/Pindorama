using System.Linq;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject cardPanel;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private SlotController slotController;
    [SerializeField] private CombatLogic combatLogic;
    public bool isCardPanelActive = true;

    public void CardCreator(int cardCount)
    {
        for (int i = 0; i < cardCount; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardPanel.transform);
            card.name = "Card " + (i + 1);
        }
    }

    void Update()
    {
        if (combatLogic.GetCombatPhase() == 0)
        {
            foreach (Slot slot in slotController.GetSlots())
            {
                if (slot.currentCharacter == null)
                {
                    return;
                }
            }
            cardPanel.SetActive(false);
            combatLogic.SetAgents();
            combatLogic.UpdateCombatPhase(1);
        }
    }
}
