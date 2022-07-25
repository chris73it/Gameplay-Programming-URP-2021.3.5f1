using UnityEngine;

public class Aiming : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;
    InputController inputController;
    [SerializeField] GameObject targetForWhenWeHitNothing;
    [SerializeField] GameObject muzzle;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] TrailRenderer laserTrail;
    [SerializeField] AudioSource laserSound;

    const float debugDrawLineDuration = 0.1f;

    void Start()
    {
        var __app = GameObject.Find("__app");
        inputController = __app.GetComponent<InputController>();
    }

    GameObject Shoot()
    {
        //Debug.Log("Shooting");
        ray.origin = muzzle.transform.position;
        ray.direction = muzzle.transform.forward;

        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.Log("Hitting something: " + hitInfo.transform.gameObject.name);
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.green, debugDrawLineDuration);

            var tracer = Instantiate(laserTrail, ray.origin, Quaternion.identity);
            tracer.AddPosition(ray.origin);
            tracer.transform.position = hitInfo.point;

            return hitInfo.transform.gameObject;
        }
        else
        {
            //Debug.Log("Hitting NOTHING :-(");

            var tracer = Instantiate(laserTrail, ray.origin, Quaternion.identity);
            tracer.AddPosition(ray.origin);
            tracer.transform.position = targetForWhenWeHitNothing.transform.position;

            Debug.DrawLine(transform.position, targetForWhenWeHitNothing.transform.position, Color.red, debugDrawLineDuration);
            return null;
        }
    }

    private void Update()
    {
        // Are we presing the shooting button (Shift)?
        Debug.Log("inputController.IsShootPressed " + inputController.IsShootPressed);
        if (inputController.IsShootPressed)
        {
            Debug.Log("laserSound.Play()");
            if (!laserSound.isPlaying)
            {
                laserSound.Play();
            }
            
            GameObject objectWeAreAimingAt = Shoot();
            if (objectWeAreAimingAt != null)
            {
                Target target = objectWeAreAimingAt.GetComponent<Target>();
                if (target != null)
                {
                    muzzleFlash.Emit(1);

                    hitEffect.transform.position = hitInfo.point;
                    hitEffect.transform.forward = hitInfo.normal;
                    hitEffect.Emit(1);

                    target.Hit(1);
                }
            }
        }
        else
        {
            Debug.Log("laserSound.Stop()");
            laserSound.Stop();
        }
    }
}
