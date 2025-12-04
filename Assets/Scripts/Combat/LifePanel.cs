using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private CombatLogic combatLogic;
    private SlotController slotController;
    private TextMeshProUGUI panelText;
    void Start()
    {
        slotController = combatLogic.gameObject.GetComponent<SlotController>();
        panelText = GetComponentInChildren<TextMeshProUGUI>();
        panelText.text = "";
    }

    void Update()
    {
        if (combatLogic.GetCombatPhase() > 0 && combatLogic.GetCombatPhase() < 4)
        {
            foreach (Slot slot in slotController.GetSlots())
            {
                if (slot.currentCharacter.transform.GetComponent<BoxCollider2D>().bounds.Contains(Input.mousePosition) || slot.currentCharacter.transform.GetComponent<BoxCollider2D>().bounds.Contains(Input.mousePosition + Vector3.forward))
                {
                    transform.position = Input.mousePosition + new Vector3(0, 80, 0);
                    if (slot.currentCharacter.GetComponent<Character>() != null)
                    {
                        panelText.text = "Vida: " + slot.currentCharacter.GetComponent<Character>().aliado.vida;
                    }
                    else
                    {
                        panelText.text = "Vida: " + slot.currentCharacter.GetComponent<Enemy>().inimigo.vida;
                    }
                    break;
                }
                transform.position = new Vector3(2000, 2000, 2000);
            }
        }

    }

}
