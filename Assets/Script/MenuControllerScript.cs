using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControllerScript : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelCompendio;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirCompendio()
    {
        painelMenuInicial.SetActive(false);
        painelCompendio.SetActive(true);
    }

    public void FecharCompendio()
    {
        painelMenuInicial.SetActive(true);
        painelCompendio.SetActive(false);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
