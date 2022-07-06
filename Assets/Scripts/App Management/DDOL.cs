using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    // Tells the _app in the _preload scene, what scene to load next
    //  (it can be temporarily overriden on a per-scene-basis by DevPreload::RunMeOverride.)
    [SerializeField] int nextBuildIndex;

    private void Awake()
    {
        // Check _preloadSceneBuildIndex is sane, and warn the user otherwise
        var _preloadSceneBuildIndex = gameObject.scene.buildIndex;
        if (_preloadSceneBuildIndex != 0)
        {
            Debug.LogWarning("The _preloadSceneBuildIndex is not zero (" + _preloadSceneBuildIndex + ")");
        }
        Debug.Log("The _preload scene build index is " + _preloadSceneBuildIndex);

        // After calling DontDestroyOnLoad() gameObject.scene.buildIndex will return -1
        DontDestroyOnLoad(gameObject);

        // Check nextBuildIndex is sane, and fix it otherwise
        if (nextBuildIndex <= 0)
        {
            nextBuildIndex = _preloadSceneBuildIndex + 1; // Load the scene after the _preload scene
            Debug.LogWarning("DDOL::nextBuildIndex is non-positive so setting it to " + nextBuildIndex);
        }
        Debug.Log("DDOL::nextBuildIndex is " + nextBuildIndex);

        // Check Grid.nextBuildIndex is sane, and fix it otherwise
        if (Grid.nextBuildIndexOverride < 0)
        {
            Debug.LogWarning("Grid.nextBuildIndex is negative (" + Grid.nextBuildIndexOverride + ") so setting it to 0"); 
            Grid.nextBuildIndexOverride = 0;
        }

        if (Grid.nextBuildIndexOverride == 0)
        {
            Debug.Log("Loading scene DDOL::nextBuildIndex (" + nextBuildIndex + ")");
            SceneManager.LoadScene(nextBuildIndex);
        }
        else
        {
            Debug.LogWarning("Overriding DDOL::nextBuildIndex (" + nextBuildIndex + ") with Grid.nextBuildIndexOverride (" + Grid.nextBuildIndexOverride + ")");
            SceneManager.LoadScene(Grid.nextBuildIndexOverride);
        }
    }
}