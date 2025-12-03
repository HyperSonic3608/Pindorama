using UnityEngine;

public class FPSControllerScript : MonoBehaviour
{
    [SerializeField] int targetFPS = 60;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }

}
