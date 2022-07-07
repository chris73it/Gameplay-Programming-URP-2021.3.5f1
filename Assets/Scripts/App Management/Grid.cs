using UnityEngine;

// This class caches the General Behaviors of the __app
static class Grid
{
    // Used by a specific scene to override DDOL::nextBuildIndex
    //  via the DevPreload::RunMeOverride (zero means do not override.)
    public static int nextBuildIndexOverride = 0;

    public static GameObject __app;
    // Below all general behaviors
    public static InputController input;

    static Grid()
    {
        __app = GameObject.Find("__app");
        if (__app != null)
        {
            input = __app.GetComponent<InputController>();
        }
    }
}