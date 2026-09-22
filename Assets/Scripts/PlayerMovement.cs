using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8.0f;
    [SerializeField] float jumpPower = 13.0f;
    [SerializeField] float deathBounce = 10f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gun;

    Vector2 moveInput;
    Rigidbody2D playerRB;
    BoxCollider2D playerFeetCollider;
    CapsuleCollider2D playerBodyCollider;
    Animator playerAnimator;
    LayerMask groundLayer;
    LayerMask enemiesLayer;

    public bool IsPlayerAlive { get; private set; } = true;
    public int CoinCount { get; private set; }

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        groundLayer = LayerMask.GetMask("Ground");
        enemiesLayer = LayerMask.GetMask("Enemies");

    }

    private void FixedUpdate()
    {
        if (!IsPlayerAlive) return;

        Run();
        FlipSprite();
        CheckDeath();
    }

    private void OnMove(InputValue value)
    {
        if (!IsPlayerAlive) return;

        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (!IsPlayerAlive) return;

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
    private void OnAttack(InputValue value)
    {
        if (!IsPlayerAlive) return;
        Instantiate(bulletPrefab, gun.position, transform.rotation);
    }

    private void CheckDeath()
    {
        if (playerBodyCollider.IsTouchingLayers(enemiesLayer) || playerFeetCollider.IsTouchingLayers(enemiesLayer))
        {
            IsPlayerAlive = false;
            playerAnimator.SetTrigger("Dying");
            playerRB.linearVelocityY = deathBounce;
        }
    }

    public void AddCoin()
    {
        CoinCount++;
        Debug.Log("Coins: " + CoinCount);
    }
}
