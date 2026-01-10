using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class InteriorMalocaTupinambaScript : MonoBehaviour
{
    private BoxCollider2D playerBoxCollider2D;
    private PolygonCollider2D polygonCollider2D;
    private Tilemap tilemap;
    private Color color;
    [SerializeField] Light2D globalLight2D;
    [SerializeField] PixelPerfectCamera myCamera;
    [SerializeField] float defaultLightIntensity;
    [SerializeField] float modifiedLightIntensity;
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        playerBoxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        tilemap = GetComponent<Tilemap>();
        color = tilemap.color;
    }

    void Update()
    {
        if (polygonCollider2D.IsTouching(playerBoxCollider2D))
        {
            tilemap.color = new Color(1f, 1f, 1f, 0.2f);
            globalLight2D.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            globalLight2D.intensity = modifiedLightIntensity;
            myCamera.assetsPPU = 64;
        }
        else
        {
            tilemap.color = color;
            globalLight2D.color = new Color(1f, 1f, 1f, 1f);
            globalLight2D.intensity = defaultLightIntensity;
            myCamera.assetsPPU = 32;
        }
    }
}
