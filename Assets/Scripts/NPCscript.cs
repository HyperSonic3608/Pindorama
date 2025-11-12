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

    private Transform[] waypoints;
    private int currentWaypoint;
    private bool isWaiting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = new Transform[RotaNPC.childCount];

        for (int i = 0; i < RotaNPC.childCount; i++)
        {
            waypoints[i] = RotaNPC.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            return;
        }
        moveToWaypoint();
    }

    void moveToWaypoint()
    {
        Transform target = waypoints[currentWaypoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }
    
    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypoint = loopWaypoints ? (currentWaypoint + 1) % waypoints.Length : Mathf.Min(currentWaypoint + 1, waypoints.Length - 1);

        isWaiting = false;
    }
}