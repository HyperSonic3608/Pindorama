using UnityEngine;

public class CodexControl : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject buttons;
    void Start()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
    }

    public void AbrirPovos()
    {
        page1.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirXamanismo()
    {
        page2.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirItens()
    {
        page3.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirLocalizacoes()
    {
        page4.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirPersonagens()
    {
        page5.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirOponentes()
    {
        page6.SetActive(true);
        buttons.SetActive(false);
    }

    public void Voltar()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);

        buttons.SetActive(true);
    }
}
