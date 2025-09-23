using UnityEngine;

public class Dado : MonoBehaviour
{
    private CombatLogic combatLogic;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
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
        int randomValue = Random.Range(1, 7);
        animator.SetFloat("DiceValue", randomValue);
        animator.SetBool("Roll", true);
    }
}
