using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{
    public GameObject character;
    [SerializeField] private GameObject[] actionButtons;
    [SerializeField] private Image characterImage;
    [SerializeField] private CombatLogic combatLogic;
    public int lastAttackType { get; private set; } = 0;
    public int lastButtonPressed { get; private set; }
    private Animator animator;

    public void UpdateMenu()
    {
        characterImage.sprite = character.GetComponent<Character>().image.sprite;
        animator = GetComponent<Animator>();
        animator.SetFloat("CardRarity", character.GetComponent<Character>().rarity);
        TipoAtaque(lastAttackType);
    }
    public void Close()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x * -1, transform.position.y, transform.position.z), transform.rotation);
        combatLogic.UpdateCombatPhase(1);
    }

    public void TipoAtaque(int tipoAtaque)
    {
        int i = 0;
        foreach (var button in actionButtons)
        {
            switch (tipoAtaque)
            {
                case 0:
                    button.GetComponentInChildren<TextMeshProUGUI>().text = character.GetComponent<Character>().attackTexts.dialogueLines[i];
                    break;

                case 1:
                    button.GetComponentInChildren<TextMeshProUGUI>().text = "";
                    break;

                default:
                    break;
            }

            button.GetComponent<Button>().interactable = button.GetComponentInChildren<TextMeshProUGUI>().text == "" ? false : true;
            lastButtonPressed = -1;
            lastAttackType = tipoAtaque;
            i++;
        }
    }

    public void ActionButton(GameObject button)
    {
        for (int i = 0; i < actionButtons.Length; i++)
        {
            if (actionButtons[i].gameObject == button)
            {
                lastButtonPressed = i;
            }
        }
        combatLogic.UpdateCombatPhase(3);
    }
}
