using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevelX : MonoBehaviour
{
    GameObject __app;
    TargetDowncounter targetDowncounter;
    GoToLevelX goToLevelX;
    [SerializeField] GameObject victoryCanvas;

    private void Start()
    {
        __app = GameObject.Find("__app");
        targetDowncounter = __app.GetComponent<TargetDowncounter>();
        goToLevelX = __app.GetComponent<GoToLevelX>();
    }

    public void LoadLevelByBuildIndex(int nextBuildIndex)
    {
        targetDowncounter.targetDowncounter[0] = nextBuildIndex;
        if (nextBuildIndex < targetDowncounter.targetDowncounter.Length)
        {
            SceneManager.LoadScene(nextBuildIndex);
        }
        else
        {
            victoryCanvas.SetActive(true);
        }
    }
}
