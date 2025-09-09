using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeOpacityScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerBoxCollider2D;
    private PolygonCollider2D polygonCollider2D;
    private Color color;
    private Tilemap[] tilemaps;
    void Start()
    {
        tilemaps = GetComponentsInChildren<Tilemap>();
        color = tilemaps[0].color;
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (polygonCollider2D.IsTouching(playerBoxCollider2D))
        {
            for(int i = 0; i < 10; i++)
            {
                tilemaps[i].color = new Color(1f, 1f, 1f, 0.1f);
            }
            //light2D.color = new Color(0.2f, 0.2f, 0.2f, 1f);
        }
        else
        {
            for(int i = 0; i < 10; i++)
            {
                tilemaps[i].color = color;
            }
            //light2D.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
