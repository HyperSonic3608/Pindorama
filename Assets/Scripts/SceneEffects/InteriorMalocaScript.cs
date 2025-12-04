using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class InteriorMalocaScript : MonoBehaviour
{
    private BoxCollider2D playerBoxCollider2D;
    private CompositeCollider2D compositeCollider2D;
    private Tilemap tilemap;
    private Color color;
    [SerializeField] Light2D light2D;
    [SerializeField] new PixelPerfectCamera camera;

    void Start()
    {
        compositeCollider2D = GetComponent<CompositeCollider2D>();
        playerBoxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        tilemap = GetComponent<Tilemap>();
        color = tilemap.color;
    }

    void Update()
    {
        if (compositeCollider2D.IsTouching(playerBoxCollider2D))
        {
            tilemap.color = new Color(1f, 1f, 1f, 0.2f);
            light2D.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            camera.assetsPPU = 48;
        }
        else
        {
            tilemap.color = color;
            light2D.color = new Color(1f, 1f, 1f, 1f);
            camera.assetsPPU = 32;
        }

    }
}
