using UnityEngine;
using UnityEngine.EventSystems;

public class CartaController : MonoBehaviour
{
    public GameObject cartaPanel;
    public GameObject cartaPrefab;
    public int cartaCount;

    void Start()
    {
        for (int i = 0; i < cartaCount; i++)
        {
            GameObject carta = Instantiate(cartaPrefab, cartaPanel.transform);
            carta.name = "Carta " + (i + 1);
        }
    }
}
