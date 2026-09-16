using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Vector2 moveInput;
    Rigidbody2D playerRB;
    Animator playerAnimator;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        playerRB.linearVelocity = new Vector2(moveInput.x * moveSpeed, playerRB.linearVelocityY);

        bool hasSpeed = Mathf.Abs(playerRB.linearVelocityX) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", hasSpeed);

    }

    void FlipSprite()
    {
        bool hasSpeed = Mathf.Abs(playerRB.linearVelocityX) > Mathf.Epsilon;
        if (hasSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRB.linearVelocityX), 1f);
        }
    }
}
