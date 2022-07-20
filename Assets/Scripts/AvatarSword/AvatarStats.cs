using UnityEngine;

public class AvatarStats : MonoBehaviour
{
    public float energyLeft;
    public float livesLeft;

    [SerializeField] GameObject lightSaber;
    private bool hasSword;
    public bool HasSword
    {
        get { return hasSword; }
        set { hasSword = value; lightSaber.SetActive(value); }
    }
}
