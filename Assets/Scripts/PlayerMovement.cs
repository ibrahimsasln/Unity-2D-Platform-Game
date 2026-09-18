using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8.0f;
    [SerializeField] float jumpPower = 13.0f;
    

    Vector2 moveInput;
    Rigidbody2D playerRB;
    BoxCollider2D playerFeetCollider;
    Animator playerAnimator;
    LayerMask groundLayer;
    
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        Run();
        FlipSprite();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && playerFeetCollider.IsTouchingLayers(groundLayer))
        {
            playerRB.linearVelocityY = jumpPower;
        }
    }

    private void Run()
    {
        playerRB.linearVelocity = new Vector2(moveInput.x * moveSpeed, playerRB.linearVelocityY);

        bool hasSpeed = Mathf.Abs(playerRB.linearVelocityX) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", hasSpeed);

    }

    private void FlipSprite()
    {
        bool hasSpeed = Mathf.Abs(playerRB.linearVelocityX) > Mathf.Epsilon;
        if (hasSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRB.linearVelocityX), 1f);
        }
    }
}
