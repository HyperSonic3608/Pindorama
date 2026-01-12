using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private CombatLogic combatLogic;
    [SerializeField] private ActionMenu actionMenu;

    public void Show()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        transform.parent.GetComponent<Image>().enabled = false;
        transform.GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        animator.SetFloat("TypeAction", combatLogic.lastActionType);
        animator.SetFloat("TypeWeapon", (float)combatLogic.realizador.arma.tipo);
        animator.SetFloat("TypeChar", (float)combatLogic.realizador.tipo);
        animator.SetFloat("TypeOption", combatLogic.lastButtonPressed);
        animator.SetFloat("TypeRarity", (float)combatLogic.realizador.arma.raridade);
        animator.SetBool("isActive", true);
        transform.parent.GetComponent<Image>().enabled = true;
        transform.GetComponent<Image>().enabled = true;
        transform.GetChild(0).GetComponent<Image>().enabled = true;
        if (combatLogic.lastActionType == 0)
        {
            SoundEffectManager.Play("Attack");
        }
        else
        {
            SoundEffectManager.Play("Heal");
        }

    }

}
