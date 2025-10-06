using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{
    public GameObject character;
    [SerializeField] private GameObject[] actionButtons;
    [SerializeField] private Image characterImage;
    [SerializeField] private CombatLogic combatLogic;
    public GameObject lastButtonPressed;
    private Animator animator;

    public void UpdateImage()
    {
        characterImage.sprite = character.GetComponent<Image>().sprite;
        animator = GetComponent<Animator>();
        animator.SetFloat("CardRarity", character.GetComponent<Character>().CharacterRarity);
    }
    public void Close()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x * -1, transform.position.y, transform.position.z), transform.rotation);
        combatLogic.UpdateCombatPhase(1);
    }

    public void TipoAtaque(int tipoAtaque)
    {
        int i = 1;
        foreach (var button in actionButtons)
        {
            switch (tipoAtaque)
            {
                case 0:
                    button.GetComponentInChildren<TextMeshProUGUI>().text = "Ataque Fisico " + i;
                    break;

                case 1:
                    button.GetComponentInChildren<TextMeshProUGUI>().text = "Ataque Mágico " + i;
                    break;

                default:
                    break;

            }
            button.GetComponent<Button>().interactable = true;
            lastButtonPressed = null;
            i++;
        }
    }

    public void ActionButton(GameObject button)
    {
        lastButtonPressed = button;
        combatLogic.UpdateCombatPhase(3);
    }
}
