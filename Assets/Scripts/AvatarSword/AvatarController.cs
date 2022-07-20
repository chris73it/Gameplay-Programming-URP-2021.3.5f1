using UnityEngine;

public class AvatarController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] Transform forwardPoint;
    //[SerializeField] Transform rightPoint;

    private Vector3 currentMovement;
    public void OnMoveInput(Vector2 moveInput)
    {
        //y needs to preserve its value from the previous Update.
        currentMovement.x = moveInput.x; // -1 if A is pressed; +1 if D is pressed
        currentMovement.y = 0f;
        currentMovement.z = moveInput.y; //-1 if S is pressed; +1 if W is pressed
        //Debug.Log("currentMovement " + currentMovement);
    }

    //private float currentRotation;
    //public void OnRotateInput(float rotateInput)
    //{
    //    currentRotation = rotateInput; // -1 if Q is pressed; +1 if E is pressed
    //    //Debug.Log("currentRotation " + currentRotation);
    //}

    Ray ray;
    RaycastHit hitInfo;
    private void Update()
    {
        //transform.position += currentMovement * moveSpeed * Time.deltaTime;
        Vector3 fwdDir = forwardPoint.position - transform.position;
        //Vector3 rightDir = rightPoint.position - transform.position;
        transform.position += fwdDir * currentMovement.z * moveSpeed * Time.deltaTime;
        //transform.position += rightDir * currentMovement.x * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, currentMovement.x * rotSpeed * Time.deltaTime);
    }
}