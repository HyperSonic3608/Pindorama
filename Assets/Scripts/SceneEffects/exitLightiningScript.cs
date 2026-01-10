using UnityEngine;
using UnityEngine.Rendering.Universal;

public class exitLightiningScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerBoxCollider2D;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] Light2D globalLight2D;
    [SerializeField] Light2D playerLight2D;

    void Update()
    {
        if (boxCollider2D.IsTouching(playerBoxCollider2D))
        {
            globalLight2D.intensity = 0f;
            playerLight2D.intensity = 0f;
        }
    }
}
