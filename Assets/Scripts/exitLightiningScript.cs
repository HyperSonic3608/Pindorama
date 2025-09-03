using UnityEngine;
using UnityEngine.Rendering.Universal;

public class exitLightiningScript : MonoBehaviour
{
    private BoxCollider2D playerBoxCollider2D;
    private BoxCollider2D boxCollider2D;
    [SerializeField] Light2D light2D;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerBoxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (boxCollider2D.IsTouching(playerBoxCollider2D))
        {
            do
            {
                light2D.intensity -= 0.1f;
            } while (light2D.intensity >= 0.2f);
        }
        else
        {
            do
            {
                light2D.intensity += 0.1f;
            } while (light2D.intensity <= 1);
        }
    }
}
