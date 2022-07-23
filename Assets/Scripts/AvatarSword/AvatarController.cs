using UnityEngine;

public class AvatarController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] Transform forwardPoint;
    [SerializeField] Transform rightPoint;

    private Vector3 currentMovement;
    public void OnMoveInput(Vector2 moveInput)
    {
        currentMovement.x = moveInput.x; // -1 if A is pressed; +1 if D is pressed
        currentMovement.y = 0f;
        currentMovement.z = moveInput.y; //-1 if S is pressed; +1 if W is pressed
        //Debug.Log("currentMovement " + currentMovement);
    }

    private Vector3 currentLook;
    public void OnLookInput(Vector2 lookInput)
    {
        currentLook.x = lookInput.x; // -1 if A is pressed; +1 if D is pressed
        currentLook.y = 0f;
        currentLook.z = lookInput.y; //-1 if S is pressed; +1 if W is pressed
        //Debug.Log("currentLook " + currentLook);
    }

    //Ray ray;
    //RaycastHit hitInfo;
    private void LateUpdate()
    {
        Vector3 fwdDir = forwardPoint.position - transform.position;
        transform.position += fwdDir * currentMovement.z * moveSpeed * Time.deltaTime;

        Vector3 rightDir = rightPoint.position - transform.position;
        transform.position += rightDir * currentMovement.x * moveSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, currentLook.x * rotSpeed * Time.deltaTime);
    }
}