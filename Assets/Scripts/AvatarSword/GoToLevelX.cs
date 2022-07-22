using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToLevelX : MonoBehaviour
{
    GameObject __app;
    TargetDowncounter targetDowncounter;
    
    [SerializeField] GameObject victoryCanvas;
    
    [SerializeField] float levelXPersistenceSecs;
    [SerializeField] GameObject levelXCanvas;
    TextMeshProUGUI levelX;

    private void Awake()
    {
        levelX = levelXCanvas.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        __app = GameObject.Find("__app");
        targetDowncounter = __app.GetComponent<TargetDowncounter>();
    }

    public void LoadLevelByBuildIndex(int nextBuildIndex)
    {
        Debug.Log("nextBuildIndex "  + nextBuildIndex);

        targetDowncounter.targetDowncounter[0] = nextBuildIndex;
        if (nextBuildIndex < targetDowncounter.targetDowncounter.Length)
        {
            StartCoroutine("DisplayLevelX", nextBuildIndex);
            SceneManager.LoadScene(nextBuildIndex);
        }
        else
        {
            victoryCanvas.SetActive(true);
        }
    }

    IEnumerator DisplayLevelX(int nextBuildIndex)
    {
        levelX.text = "Level " + nextBuildIndex;
        levelX.gameObject.SetActive(true);
        yield return new WaitForSeconds(levelXPersistenceSecs);
        levelX.gameObject.SetActive(false);
    }
}
