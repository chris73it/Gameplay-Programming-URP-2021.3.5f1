using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    GameObject __app;
    AvatarStats avatarStats;

    private void Start()
    {
        __app = GameObject.Find("__app");
        avatarStats = __app.GetComponent<AvatarStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("other.tag " + other.tag);

        if (other.tag == "Player")
        {
            PickUpTheSword();
        }
    }

    private void PickUpTheSword()
    {
        // This activates the lightsaber parented on the space chiken
        avatarStats.HasSword = true;
        gameObject.SetActive(false);
    }
}