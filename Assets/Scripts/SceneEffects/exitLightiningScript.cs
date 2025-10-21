using UnityEngine;
using UnityEngine.Rendering.Universal;

public class exitLightiningScript : MonoBehaviour
{
    private BoxCollider2D playerBoxCollider2D;
    private BoxCollider2D boxCollider2D;
    [SerializeField] Light2D GlobalLight2D;
    [SerializeField] Light2D playerLight2D;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerBoxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (boxCollider2D.IsTouching(playerBoxCollider2D))
        {
            GlobalLight2D.enabled = false;
            playerLight2D.enabled = false;
        }
    }
}
