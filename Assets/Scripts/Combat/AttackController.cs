using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float animationId;
    void Start()
    {
        animator.SetFloat("Type", 0);
    }

    void Update()
    {
        animator.SetFloat("Type", animationId);
    }
}
