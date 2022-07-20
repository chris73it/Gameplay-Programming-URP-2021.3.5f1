using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevelX : MonoBehaviour
{
    public void LoadLevelByBuildIndex(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
