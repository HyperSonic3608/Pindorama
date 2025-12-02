using UnityEngine;

public class PagesControl : MonoBehaviour
{
    public GameObject compendio;
    public GameObject consumiveis;
    public GameObject aliados;
    public GameObject menu;

    void Start()
    {
        compendio.SetActive(true);
        consumiveis.SetActive(false);
        aliados.SetActive(false);
    }

    public void AbrirCompendio()
    {
        compendio.SetActive(true);
        consumiveis.SetActive(false);
        aliados.SetActive(false);
    }

    public void AbrirConsumiveis()
    {
        compendio.SetActive(false);
        consumiveis.SetActive(true);
        aliados.SetActive(false);
    }

    public void AbrirAliados()
    {
        compendio.SetActive(false);
        consumiveis.SetActive(false);
        aliados.SetActive(true);
    }

    public void CloseMenu ()
    {
        menu.SetActive(false);
    }
}
