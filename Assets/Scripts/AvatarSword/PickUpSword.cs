using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    GameObject __app;
    public AvatarStats avatarStats;
    [SerializeField] GameObject sworddPivot;
    GameObject item;

    private void Start()
    {
        __app = GameObject.Find("__app");
        avatarStats = __app.GetComponent<AvatarStats>();

        item = GameObject.Find("Item");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other.tag " + other.tag);

        if (other.tag == "Player")
        {
            PickUpTheSword();
        }
    }

    private void PickUpTheSword()
    {
        avatarStats.hasSword = true;
        sworddPivot.transform.parent = item.transform;
        item.transform.rotation = Quaternion.Euler(0, 0, 90f);
        sworddPivot.transform.localPosition = new Vector3(0, 0, 0);
    }
}
