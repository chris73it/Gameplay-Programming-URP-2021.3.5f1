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

    [SerializeField] GameObject avatar;
    [SerializeField] GameObject mainCamera;

    RotateAvatar rotateAvatar;

    private void Awake()
    {
        levelX = levelXCanvas.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        __app = GameObject.Find("__app");
        targetDowncounter = __app.GetComponent<TargetDowncounter>();
        rotateAvatar = __app.GetComponent<RotateAvatar>();
    }

    public void LoadLevelByBuildIndex(int nextBuildIndex)
    {
        Debug.Log("nextBuildIndex "  + nextBuildIndex);

        targetDowncounter.targetDowncounter[0] = nextBuildIndex;
        if (nextBuildIndex < targetDowncounter.targetDowncounter.Length)
        {
            // In the Menu scene the avatar spins, so we realign the avatar at the start of level 1.
            //   1. Disable the RotateAvatar component, so the avatar stops spinning. 
            //   2. Straight up the avatar to look forward (Quaternion.identity does that.)
            //   3. Reparent the main camera to the avatar.
            rotateAvatar.enabled = false;
            avatar.transform.rotation = Quaternion.identity;
            mainCamera.transform.parent = avatar.transform;

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
