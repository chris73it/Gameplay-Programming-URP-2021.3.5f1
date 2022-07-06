// This should run absolutely first; use script-execution-order to do so.
// (of course, normally never use the script-execution-order feature,
// this is an unusual case, just for development.)
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevPreload : MonoBehaviour
{
    [SerializeField] bool RunMeOverride;

    void Awake()
    {
        Debug.Log("This scene buildIndex is " + gameObject.scene.buildIndex);

        GameObject check = GameObject.Find("__app");
        if (check == null)
        {
            if (RunMeOverride)
            {
                Grid.nextBuildIndexOverride = gameObject.scene.buildIndex;
            }
            SceneManager.LoadScene("_preload");
        }
    }
}