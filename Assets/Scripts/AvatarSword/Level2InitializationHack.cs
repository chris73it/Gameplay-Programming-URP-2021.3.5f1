using UnityEngine;

public class Level2InitializationHack : MonoBehaviour
{
    GameObject __app;
    AvatarStats avatarStats;

    void Start()
    {
        __app = GameObject.Find("__app");
        avatarStats = __app.GetComponent<AvatarStats>();
        avatarStats.hasSword = true;
    }
}
