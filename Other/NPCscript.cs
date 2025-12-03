using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPCscript : MonoBehaviour
{
    NPC npc; 
    public Transform RotaNPC;
    public float moveSpeed = 2f;
    public float waitTime = 2f;
    public bool loopWaypoints = true;
    public bool smoking = false;
    public bool canTalk = false;
    public bool canWalk = false;

    public Component NPCDialogueScript;

    private Animator animator;

    private Transform[] waypoints;
    private int currentWaypoint;
    private bool isWaiting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<NPCDialogueScript>().enabled = false;
        animator = GetComponent<Animator>();
        Smoke(smoking);
        waypoints = new Transform[RotaNPC.childCount];

        for (int i = 0; i < RotaNPC.childCount; i++)
        {
            waypoints[i] = RotaNPC.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
        {
            if (isWaiting)
            {
                animator.SetBool("isWalking", false);
                return;
            }
            moveToWaypoint();
        }
        if (canTalk)
        {
            GetComponent<NPCDialogueScript>().enabled = true;
        }
        
    }

    void moveToWaypoint()
    {
        Transform target = waypoints[currentWaypoint];

        Vector2 direction = (target.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        animator.SetFloat("InputX", direction.x);
        animator.SetFloat("InputY", direction.y);
        animator.SetBool("isWalking", true);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }
    
    IEnumerator WaitAtWaypoint()
    {
        animator.SetBool("isWalking", false);
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypoint = loopWaypoints ? (currentWaypoint + 1) % waypoints.Length : Mathf.Min(currentWaypoint + 1, waypoints.Length - 1);

        isWaiting = false;
    }

    public void Smoke(bool smoking)
    {
        animator.SetBool("isSmoking", smoking);
    }
}