using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    static readonly int IsRunningHash = Animator.StringToHash("isRunning");

    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpPower = 13f;

    PlayerHealth playerHealth;
    Rigidbody2D playerRB;
    BoxCollider2D feetCollider;
    Animator playerAnimator;
    LayerMask groundLayer;
    Vector2 moveInput;

    bool IsGrounded => feetCollider.IsTouchingLayers(groundLayer);

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerRB = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        if (!playerHealth.IsAlive) return;

        playerRB.linearVelocityX = moveInput.x * moveSpeed;

        bool isMoving = Mathf.Abs(playerRB.linearVelocityX) > Mathf.Epsilon;
        playerAnimator.SetBool(IsRunningHash, isMoving);

        if (isMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRB.linearVelocityX), 1f);
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (!playerHealth.IsAlive) return;

        if (value.isPressed && IsGrounded)
        {
            playerRB.linearVelocityY = jumpPower;
        }
    }
}
