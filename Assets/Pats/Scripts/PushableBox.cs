using UnityEngine;

public class PushableBox : MonoBehaviour
{
    [SerializeField] private float pushSpeed = 3f;
    private bool isBeingPushed = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetPushing(bool pushing)
    {
        isBeingPushed = pushing;
    }

    private void FixedUpdate()
    {
        if (isBeingPushed)
        {
            Vector3 playerVelocity = PlayerInput.Instance.GetMoveDirection();

            // Only move the box if it's not blocked
            if (!IsBlocked(playerVelocity))
            {
                rb.velocity = new Vector3(playerVelocity.x, 0, playerVelocity.z) * pushSpeed;
            }
            else
            {
                rb.velocity = Vector3.zero; // Stop the box from moving
            }
        }
    }
    // Detect if the box is blocked by something
    private bool IsBlocked(Vector3 moveDirection)
    {
        float checkDistance = 0.1f; // Small buffer distance
        RaycastHit hit;

        // Cast a ray in the movement direction to check for obstacles
        if (Physics.Raycast(transform.position, moveDirection, out hit, checkDistance))
        {
            return hit.collider != null && !hit.collider.CompareTag("Player"); // Ignore player
        }

        return false;
    }
}



