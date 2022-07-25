using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToLevelX : MonoBehaviour
{
    GameObject __app;
    TargetDowncounter targetDowncounter;
    
    [SerializeField] GameObject victoryText;
    
    [SerializeField] float levelXPersistenceSecs;
    [SerializeField] GameObject levelXCanvas;
    TextMeshProUGUI levelX;

    [SerializeField] GameObject avatar;
    [SerializeField] GameObject mainCamera;

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
            // In the Menu scene the avatar spins, so we realign the avatar at the start of level 1.
            //   1. Straight up the avatar to look forward (Quaternion.identity does that.)
            //   2. Reparent the main camera to the avatar.
            avatar.transform.rotation = Quaternion.identity;
            mainCamera.transform.parent = avatar.transform;

            SceneManager.LoadScene(nextBuildIndex);
            StartCoroutine("DisplayLevelX", nextBuildIndex);
        }
        else
        {
            victoryText.SetActive(true);
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