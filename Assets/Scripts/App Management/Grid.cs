using UnityEngine;

// This class caches the General Behaviors of the __app
static class Grid
{
    // Used by a specific scene to override DDOL::nextBuildIndex
    //  via the DevPreload::RunMeOverride (zero means do not override.)
    public static int nextBuildIndexOverride = 0;

    public static GameObject __app;
    // Below all general game behaviors
    public static InputController input;

    static Grid()
    {
        var temp = GameObject.Find("__app");
        if (temp != null)
        {
            __app = temp;
            input = __app.GetComponent<InputController>();
        }
    }
}