using UnityEngine;

public class TurretStateController : MonoBehaviour
{
    private TurretState currentState;

    [Header("Player Details")]
    [SerializeField] private Transform playerTarget;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private bool playerInTrigger = false;
    

    [Header("Turret References")]
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform weaponPoint;
    [SerializeField] private Transform turretHead;
    [SerializeField] private SphereCollider turretSphereCollider;
    [SerializeField] private AudioSource laserAudioSource;

    [Header("Turret Settings")]
    [SerializeField] private bool turretDamageOn = false;
    [Tooltip("Lower = easier, Higher = harder")][SerializeField] [Range(0f, 1f)] private float turretDamage = 0.1f;
    [SerializeField] private float scanSpeed = 10f;
    [SerializeField] private float rotationMin = -90f;
    [SerializeField] private float rotationMax = 90f;

    private void Awake()
    {
        currentState = new TurretIdle(this);
        playerTarget = GameObject.Find("Player")?.transform;

    }
    void Start()
    {
        currentState.EnterState();
        laserAudioSource.loop = true;
    }
    void Update()
    {
        currentState.UpdateState(playerInTrigger);
    }
    public void SwitchState(TurretState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            if (!laserAudioSource.isPlaying)
            {
                SoundManager.instance.PlaySound(laserAudioSource);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            SoundManager.instance.StopSound(laserAudioSource);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(turretSphereCollider.transform.position,turretSphereCollider.radius);
    }

    //Getter Methods

    public Transform GetTurretHead() => turretHead;
    public SphereCollider GetTurretSphereCollider() => turretSphereCollider;
    public LineRenderer GetLineRenderer() => lineRenderer;
    public Transform GetWeaponPoint() => weaponPoint;
    public Transform GetPlayerTarget() => playerTarget;
    public LayerMask GetPlayerLayer() => playerLayer;
    public float GetScanSpeed() => scanSpeed;
    public float GetRotationMin() => rotationMin;
    public float GetRotationMax() => rotationMax;
    public float GetTurretdamage() => turretDamage;
    public bool IsPlayerInTrigger() => playerInTrigger;
    public bool TurretDamageOn() => turretDamageOn;

}
