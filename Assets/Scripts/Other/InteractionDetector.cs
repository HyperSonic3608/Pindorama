using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableRange = null;
    [SerializeField] Animator playerAnimator;

    public static bool canMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactableRange?.Interact();
            if (canMove)
            {
                canMove = true;
                playerAnimator.SetBool("isYanomamiDialogue", true);
            }
            else
            {
                playerAnimator.SetBool("isYanomamiDialogue", false);
                canMove = true;
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableRange = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableRange)
        {
            interactableRange = null;
        }
    }
}