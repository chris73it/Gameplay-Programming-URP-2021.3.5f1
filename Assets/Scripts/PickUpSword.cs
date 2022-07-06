using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    GameObject __app;
    AvatarStats avatarStats;

    void Start()
    {
        __app = GameObject.Find("__app");
        avatarStats = __app.GetComponent<AvatarStats>();
        PickUpTheSword();
    }

    void PickUpTheSword()
    {
        avatarStats.hasSword = true;
    }
}
