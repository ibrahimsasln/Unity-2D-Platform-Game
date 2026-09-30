using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    enum State { Waiting, Jumping }

    [SerializeField] float waitTime = 1.5f;
    [SerializeField] Vector2 jumpForce = new Vector2(3f, 6f);
    [SerializeField] float groundCheckDistance = 0.6f;

    Rigidbody2D slimeRB;
    Transform playerTransform;
    Health playerHealth;
    LayerMask groundLayer;

    State state = State.Waiting;
    float nextJumpTime;

    private void Awake()
    {
        slimeRB = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");

        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        playerHealth = player.GetComponent<Health>();

        nextJumpTime = Time.time + waitTime;
    }

    private void FixedUpdate()
    {
        if (playerHealth.IsDead) return;

        switch (state)
        {
            case State.Waiting:
                UpdateWaiting();
                break;
            case State.Jumping:
                UpdateJumping();
                break;
        }
    }

    private void UpdateWaiting()
    {
        slimeRB.linearVelocityX = 0f;

        if (Time.time >= nextJumpTime)
        {
            JumpTowardsPlayer();
        }
    }

    private void UpdateJumping()
    {
        bool isFalling = slimeRB.linearVelocityY <= 0f;

        if (isFalling && IsGrounded())
        {
            Land();
        }
    }

    private void JumpTowardsPlayer()
    {
        float direction = Mathf.Sign(playerTransform.position.x - transform.position.x);
        transform.localScale = new Vector2(direction, 1f);
        slimeRB.linearVelocity = new Vector2(direction * jumpForce.x, jumpForce.y);

        state = State.Jumping;
    }

    private void Land()
    {
        slimeRB.linearVelocityX = 0f;
        nextJumpTime = Time.time + waitTime;

        state = State.Waiting;
    }

    private bool IsGrounded()
    {
        bool hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, hit ? Color.green : Color.red);
        return hit;
    }
}
