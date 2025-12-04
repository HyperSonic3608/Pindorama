using UnityEngine;

public class CodexControl : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;
    public GameObject page8;
    public GameObject page9;
    public GameObject page10;
    public GameObject buttons;


    //Povos
    public GameObject TukanoPage;
    public GameObject YanomamiPage;
    public GameObject TupinambaPage;
    public GameObject PovosButtons;
    void Start()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        page7.SetActive(false);
        page8.SetActive(false);
        page9.SetActive(false);
        page10.SetActive(false);
    }

    public void AbrirPovos()
    {
        page3.SetActive(true);
        buttons.SetActive(false);
        TukanoPage.SetActive(false);
        YanomamiPage.SetActive(false);
        TupinambaPage.SetActive(false);
        PovosButtons.SetActive(true);
    }

    public void AbrirXamanismo()
    {
        page4.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirHistoria()
    {
        page1.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirLocalizacoes()
    {
        page5.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirPersonagens()
    {
        page6.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirOponentes()
    {
        page7.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirJornada()
    {
        page2.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirAmeacas()
    {
        page8.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirFauna()
    {
        page9.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirFlora()
    {
        page10.SetActive(true);
        buttons.SetActive(false);
    }

    public void AbrirTukano()
    {
        TukanoPage.SetActive(true);
        PovosButtons.SetActive(false);
    }

    public void AbrirYanomami()
    {
        YanomamiPage.SetActive(true);
        PovosButtons.SetActive(false);
    }

    public void AbrirTupinamba()
    {
        TupinambaPage.SetActive(true);
        PovosButtons.SetActive(false);
    }

    public void Voltar()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        page7.SetActive(false);
        page8.SetActive(false);
        page9.SetActive(false);
        page10.SetActive(false);
        TukanoPage.SetActive(false);
        YanomamiPage.SetActive(false);
        TupinambaPage.SetActive(false);

        buttons.SetActive(true);
    }
}
