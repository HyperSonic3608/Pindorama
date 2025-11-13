using UnityEngine;
using DG.Tweening;

public class Dice : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] animations;
    private Dado dado;
    private CombatLogic combatLogic;
    private Animator animator;
    void Start()
    {
        dado = new Dado((Dado.Tipo)6);
        animator = GetComponent<Animator>();
        updateDice();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }
    }

    public void RollDice()
    {
        dado.rolarDado();
        animator.SetFloat("DiceValue", dado.valor);
        animator.SetBool("Roll", true);
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
