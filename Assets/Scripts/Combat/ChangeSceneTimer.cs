using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTimer : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] string mapa;
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene(mapa);
        }
    }
}
