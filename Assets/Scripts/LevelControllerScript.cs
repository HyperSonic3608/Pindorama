using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LevelControllerScript : MonoBehaviour
{
    private BoxCollider2D playerBoxCollider2D;
    private BoxCollider2D boxCollider2D;
    void Start()
    {
        playerBoxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (playerBoxCollider2D.IsTouching(boxCollider2D))
        {
            SceneManager.LoadScene("CombatScreen");
            Debug.Log("Hello World!");
        }
    }

}
