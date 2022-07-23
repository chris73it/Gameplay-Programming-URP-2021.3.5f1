using UnityEngine;

public class RotateAvatar : MonoBehaviour
{
    [SerializeField] float rotSpeed;
    [SerializeField] GameObject avatar;

    void Update()
    {
        avatar.transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
    }
}
