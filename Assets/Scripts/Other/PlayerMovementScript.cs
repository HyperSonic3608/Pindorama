using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Threading;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] GameObject portal;
    [SerializeField] string mapa;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private Transform sprite;
    private InteractionDetector interactionDetector;
    private bool playingFootsteps = false;
    public float footstepsSpeed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);
        if (playingFootsteps == false)
        {
            PlayFootstep();
        }
        StartFootsteps();
        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("lastInputX", moveInput.x);
            animator.SetFloat("lastInputY", moveInput.y);
            StopFootsteps();
        }

        if (InteractionDetector.canMove)
        {

            moveInput = context.ReadValue<Vector2>();
            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (mapa == "MapaFuturo")
        {
            animator.SetBool("TukanoMode", true);
        }
        else
        {
            animator.SetBool("TukanoMode", false);
        }
    }

    public void Smoke(InputAction.CallbackContext context)
    {
        animator.SetBool("isSmoking", true);

        if (mapa == "MapaTeletransporte")
        {
            portal.SetActive(true);
            SoundEffectManager.Play("Portal");
        }

        if (context.canceled)
        {
            animator.SetBool("isSmoking", false);
        }

    }

    public void Run(InputAction.CallbackContext context)
    {
        moveSpeed = 20;

        if (context.canceled)
        {
            moveSpeed = 5;
        }
    }
    void StartFootsteps()
    {
        playingFootsteps = true;
        InvokeRepeating(nameof(PlayFootstep), 0f, footstepsSpeed);

    }
    void StopFootsteps()
    {
        playingFootsteps = false;
        CancelInvoke(nameof(PlayFootstep));
    }

    void PlayFootstep()
    {
        SoundEffectManager.Play("Footstep", true);
    }
}
