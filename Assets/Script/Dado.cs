using UnityEngine;

public class Dado : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        int randomValue = Random.Range(1, 6);
        animator.SetBool("Roll", true);
        animator.SetFloat("DiceValue", randomValue);
    }
}
