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
        SoundEffectManager.Play("Play");
    }

    public void AbrirCompendio()
    {
        painelMenuInicial.SetActive(false);
        painelCompendio.SetActive(true);
        SoundEffectManager.Play("MenuOpen");
    }

    public void FecharCompendio()
    {
        painelMenuInicial.SetActive(true);
        painelCompendio.SetActive(false);
        SoundEffectManager.Play("MenuClose");
    }

    public void SairJogo()
    {
        Application.Quit();
        SoundEffectManager.Play("MenuClose");
    }
}
