using UnityEngine;

public class Roll : StateMachineBehaviour
{
    public RectTransform dice;
    private Vector3 vector3 = new Vector3();

    void OnEnable()
    {
        dice = GameObject.FindGameObjectWithTag("Dice").GetComponent<RectTransform>();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("RandomRoll", Random.Range(0, 1f));
        if (animator.GetFloat("RandomRoll") <= 0.125f)
        {
            dice.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 206.25f);
            dice.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 256.25f);
            vector3.Set(128.13f, 926.87f, 0);
            dice.SetPositionAndRotation(vector3, dice.rotation);
        }
        animator.SetBool("Roll", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (animator.GetFloat("RandomRoll") <= 0.125f)
        {
            dice.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
            dice.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
            vector3.Set(75, 1005, 0);
            dice.SetPositionAndRotation(vector3, dice.rotation);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
