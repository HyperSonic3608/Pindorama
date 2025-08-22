using UnityEngine;
using UnityEngine.Tilemaps;

public class InteriorMalocaScript : MonoBehaviour
{
    private BoxCollider2D playerBoxCollider2D;
    private CompositeCollider2D compositeCollider2D;
    private Tilemap tilemap;
    private Color color;

    void Start()
    {
        compositeCollider2D = GetComponent<CompositeCollider2D>();
        playerBoxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        tilemap = GetComponent<Tilemap>();
        color = tilemap.color;
    }


    // Update is called once per frame
    void Update()
    {
        if (compositeCollider2D.IsTouching(playerBoxCollider2D))
        {
            tilemap.color = new Color(1f, 1f, 1f, 0.2f);
        }
        else
        {
            tilemap.color = color;
        }
        
    }
}
