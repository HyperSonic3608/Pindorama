using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CartaController : MonoBehaviour
{
    public GameObject cartaPanel;
    public GameObject cartaPrefab;
    public GameObject playerGrid;
    private Slot[] slots;
    public int cartaCount;
    public bool isCardPanelActive = true;

    void Start()
    {
        for (int i = 0; i < cartaCount; i++)
        {
            GameObject carta = Instantiate(cartaPrefab, cartaPanel.transform);
            carta.name = "Carta " + (i + 1);
        }
    }

    void Update()
    {
        if (slots == null)
            slots = GameObject.FindGameObjectsWithTag("Slot").Select(s => s.GetComponent<Slot>()).ToArray();

        foreach (Slot slot in slots)
        {
            if (slot.currentCharacter == null)
            {
                return;
            }
        }
        cartaPanel.SetActive(false);
        isCardPanelActive = false;
    }
}
