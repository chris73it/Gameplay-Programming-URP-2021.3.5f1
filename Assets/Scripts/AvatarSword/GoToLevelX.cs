using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToLevelX : MonoBehaviour
{
    GameObject __app;
    TargetDowncounter targetDowncounter;
    //GoToLevelX goToLevelX;
    TextMeshProUGUI levelX;
    [SerializeField] GameObject victoryCanvas;
    [SerializeField] GameObject levelXCanvas;
    [SerializeField] float levelXPersistenceSecs;

    private void Start()
    {
        __app = GameObject.Find("__app");
        targetDowncounter = __app.GetComponent<TargetDowncounter>();

        //goToLevelX = __app.GetComponent<GoToLevelX>();
        levelX = levelXCanvas.GetComponent<TextMeshProUGUI>();
    }

    public void LoadLevelByBuildIndex(int nextBuildIndex)
    {
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
