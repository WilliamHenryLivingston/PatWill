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
            // Move the box in the player's movement direction
            Vector3 playerVelocity = PlayerInput.Instance.GetMoveDirection();
            rb.velocity = new Vector3(playerVelocity.x, 0, playerVelocity.z) * pushSpeed;
        }
    }
}