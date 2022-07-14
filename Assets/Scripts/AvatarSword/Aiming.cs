using UnityEngine;

public class Aiming : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;
    InputController inputController;
    bool shouldShoot;
    [SerializeField] GameObject targetForWhenWeHitNothing; //FIXME
    [SerializeField] GameObject muzzle;
    [SerializeField] ParticleSystem muzzleFlash;

    const float debugDrawLineDuration = 0.1f;

    private void Awake()
    {
        
    }

    GameObject Shoot()
    {
        var __app = GameObject.Find("__app");
        inputController = __app.GetComponent<InputController>();
        Debug.Log("[Aiming::Shoot] shouldShoot" + shouldShoot);
        if (inputController.IsShootPressed)
        {
            shouldShoot = true;
        }

        ray.origin = muzzle.transform.position;
        ray.direction = muzzle.transform.forward;

        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.Log("Hitting something: " + hitInfo.transform.gameObject.name);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.green, debugDrawLineDuration);
            return hitInfo.transform.gameObject;
        }
        else
        {
            //Debug.Log("Hitting NOTHING :-(");
            Debug.DrawLine(transform.position, targetForWhenWeHitNothing.transform.position, Color.red, debugDrawLineDuration);
            return null;
        }
    }

    private void Update()
    {
        GameObject objectWeAreAimingAt = Shoot();
        if (shouldShoot && objectWeAreAimingAt != null)
        {
            shouldShoot = false;
            
            Debug.Log("[Aiming::Update] shouldShoot " + shouldShoot);
            Target target = objectWeAreAimingAt.GetComponent<Target>();
            if (target != null)
            {
                muzzleFlash.Emit(1);
                target.Hit(1);
            }
        }
    }
}
