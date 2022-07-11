using UnityEngine;

public class AvatarController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private Vector3 currentMovement;
    public void OnMoveInput(Vector2 moveInput)
    {
        //y needs to preserve its value from the previous Update.
        currentMovement.x = moveInput.x;
        currentMovement.y = 0f;
        currentMovement.z = moveInput.y;
    }

    [SerializeField] float moveSpeed;
    private void Update()
    {
        //Debug.Log("currentMovement " + currentMovement);
        transform.position += currentMovement * moveSpeed * Time.deltaTime;
    }
}