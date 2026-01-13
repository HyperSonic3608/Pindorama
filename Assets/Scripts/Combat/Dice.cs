using UnityEngine;
using DG.Tweening;

public class Dice : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] animations;
    public Dado dado { get; private set; }
    private CombatLogic combatLogic;
    private Animator animator;
    void Start()
    {
        dado = new Dado((Dado.Tipo)6);
        animator = GetComponent<Animator>();
        updateDice();
    }

    public void RollDice()
    {
        dado.rolarDado();
        animator.SetFloat("DiceValue", dado.valor);
        animator.SetBool("Roll", true);
        SoundEffectManager.Play("Dice");
    }

    public void updateDice()
    {
        switch (dado.tipo)
        {
            case Dado.Tipo.SeisLados:
                animator.runtimeAnimatorController = animations[0];
                break;

            case Dado.Tipo.VinteLados:
                animator.runtimeAnimatorController = animations[1];
                break;

            default:
                break;
        }
    }
}
