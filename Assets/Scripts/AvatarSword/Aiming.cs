using UnityEngine;

public class Aiming : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject targetForWhenWeHitNothing;
    const float debugDrawLineDuration = 0.1f;

    GameObject Aim()
    {
        ray.origin = muzzle.transform.position;
        ray.direction = muzzle.transform.forward;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log("Hitting something: " + hitInfo.transform.gameObject.name);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.green, debugDrawLineDuration);
            return hitInfo.transform.gameObject;
        }
        else
        {
            Debug.Log("Hitting NOTHING :-(");
            Debug.DrawLine(transform.position, targetForWhenWeHitNothing.transform.position, Color.red, debugDrawLineDuration);
            return null;
        }
    }

    private void Update()
    {
        GameObject objectWeAreAimingAt = Aim();
        if (objectWeAreAimingAt != null)
        {
            Target target = objectWeAreAimingAt.GetComponent<Target>();
            if (target != null)
            {
                target.Hit(1);
            }

        }
    }
}
