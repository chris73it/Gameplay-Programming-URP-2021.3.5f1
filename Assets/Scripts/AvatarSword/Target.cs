using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Target : MonoBehaviour
{
    [SerializeField] float healthDuration;
    int currentBuildIndex;

    GameObject __app;
    TargetDowncounter targetDowncounter;
    GoToLevelX goToLevelX;
    GameObject victoryCanvas;

    private void Start()
    {
        __app = GameObject.Find("__app");
        targetDowncounter = __app.GetComponent<TargetDowncounter>();
        goToLevelX = __app.GetComponent<GoToLevelX>();
        currentBuildIndex = targetDowncounter.targetDowncounter[0];

        victoryCanvas = GameObject.Find("VictoryCanvas");
    }

    public void Hit(float damageSpeed)
    {
        healthDuration -= damageSpeed * Time.deltaTime;

        if (healthDuration <= 0)
        {
            Die(0); //Die with no delays
        }
    }

    public void Die(float delay)
    {
        Destroy(gameObject, delay);

        targetDowncounter.targetDowncounter[currentBuildIndex]--;
        if (targetDowncounter.targetDowncounter[currentBuildIndex] == 0)
        {
            currentBuildIndex++;
            goToLevelX.LoadLevelByBuildIndex(currentBuildIndex);


            //if (currentBuildIndex < targetDowncounter.targetDowncounter.Length)
            //{
            //    targetDowncounter.targetDowncounter[0]++;
            //    goToLevelX.LoadLevelByBuildIndex(currentBuildIndex);
            //}
            //else
            //    victoryCanvas.SetActive(true);
        }
    }
}
