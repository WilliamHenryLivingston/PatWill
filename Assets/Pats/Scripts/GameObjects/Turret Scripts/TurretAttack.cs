using Unity.VisualScripting;
using UnityEngine;
public class TurretAttack : TurretState
{
    private HealthSystem playerHealth;
    private Transform playerTarget;
    private LayerMask playerLayer;
    private LineRenderer lineRenderer;
    private Transform weaponPoint;
    private Transform turretHead;
    private SphereCollider turretSphereCollider;
    private bool turretDamageOn = true;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private AudioClip laserSound;
    private AudioSource loopingAudioSource;
    private float turretDamage;

    
    public TurretAttack(TurretStateController turretController) : base(turretController)
    {
        base.turretController = turretController;

        playerTarget = turretController.GetPlayerTarget();
        playerLayer = turretController.GetPlayerLayer();
        lineRenderer = turretController.GetLineRenderer();
        weaponPoint = turretController.GetWeaponPoint();
        turretHead = turretController.GetTurretHead();
        turretSphereCollider = turretController.GetTurretSphereCollider();
        turretDamageOn = turretController.TurretDamageOn();
        laserSound = turretController.GetAudioClip();
        turretDamage = turretController.GetTurretdamage();

    }

    public override void EnterState()
    {
        playerHealth = PlayerInput.Instance.GetComponent<HealthSystem>();
        lineRenderer.enabled = true;
        loopingAudioSource = SoundManager.instance.PlayLoopingSoundEffect(laserSound,weaponPoint,0.5f);
    }
    public override void ExitState()
    {
        lineRenderer.enabled = false;
        
        if (loopingAudioSource != null)
        {
            loopingAudioSource.Stop();
            Object.Destroy(loopingAudioSource.gameObject);
        }

    }
    public override void UpdateState(bool playerInTrigger)
    {
        LookAtTarget();
        ShootPlayer();

        if (playerInTrigger == false)
        {
            turretController.SwitchState(new TurretIdle(turretController));
        }
    }
    public void LookAtTarget()
    {
        Vector3 direction = playerTarget.position - turretHead.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        turretHead.transform.rotation = Quaternion.Euler(0, angle, 0);
    }


    public void ShootPlayer()
    {
        Ray customRay = new Ray(weaponPoint.position, weaponPoint.transform.forward);
        RaycastHit tempHit;

        if (Physics.Raycast(customRay, out tempHit, turretSphereCollider.radius + 3, playerLayer))
        {
            if (tempHit.collider.CompareTag("Player"))
            {
                LaserLineRenderer(tempHit.point);

                if (turretDamageOn == true)
                {
                    //Debug.Log("Damaging the player");
                    playerHealth.DecreaseHealth(turretDamage);
                }
            }
            else
            {
                //Debug.Log("Target is being shielded!!");
                lineRenderer.enabled = false;

            }
        }

        Debug.DrawLine(startPoint,endPoint);
    }

    public void LaserLineRenderer(Vector3 endPoint)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, weaponPoint.position);
        lineRenderer.SetPosition(1, endPoint);
        //SoundManager.instance.PlaySoundEffect(laserSound, turretHead.transform, 0.5f);

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(startPoint, endPoint);
    }
}