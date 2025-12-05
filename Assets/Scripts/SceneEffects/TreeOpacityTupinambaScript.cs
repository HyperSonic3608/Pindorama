using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class TreeOpacityTupinambaScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerBoxCollider2D;
    private PolygonCollider2D polygonCollider2D;
    private PolygonCollider2D malocaCompositeCollider2D;
    private Color color;
    private Tilemap tilemap;
    [SerializeField] Light2D globalLight2D;
    private Light2D playerLight2D;
    [SerializeField] PixelPerfectCamera myCamera;
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        color = tilemap.color;
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        playerLight2D = GameObject.Find("Player").GetComponent<Light2D>();
        malocaCompositeCollider2D = GameObject.Find("Maloca").GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (polygonCollider2D.IsTouching(playerBoxCollider2D))
        {
            tilemap.color = new Color(1f, 1f, 1f, 0.1f);
            globalLight2D.intensity = 0.1f;
            globalLight2D.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            playerLight2D.enabled = true;
            myCamera.assetsPPU = 48;
        }
        else if (malocaCompositeCollider2D.IsTouching(playerBoxCollider2D) == false)
        {
            tilemap.color = color;
            globalLight2D.intensity = 1f;
            globalLight2D.color = new Color(1f, 1f, 1f, 1f);
            playerLight2D.enabled = false;
            myCamera.assetsPPU = 32;
        }
    }
}
