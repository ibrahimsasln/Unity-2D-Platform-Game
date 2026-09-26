using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float wallCheckDistance = 0.5f;
    [SerializeField] float groundCheckDistance = 0.7f;
    [SerializeField] float groundCheckOffset = 0.5f;

    Rigidbody2D slimeRB;
    LayerMask groundLayer;

    float Direction => Mathf.Sign(speed);

    private void Awake()
    {
        slimeRB = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        slimeRB.linearVelocity = new Vector2(speed, 0f);

        if (!IsGroundAhead() || IsWallAhead())
        {
            Flip();
        }
    }

    private bool IsWallAhead()
    {
        return CastRay(transform.position, Vector2.right * Direction, wallCheckDistance);
    }

    private bool IsGroundAhead()
    {
        Vector2 drawStartPos = (Vector2)transform.position + new Vector2(groundCheckOffset * Direction, 0f);
        return CastRay(drawStartPos, Vector2.down, groundCheckDistance);
    }

    private bool CastRay(Vector2 origin, Vector2 direction, float distance)
    {
        bool hit = Physics2D.Raycast(origin, direction, distance, groundLayer);
        Debug.DrawRay(origin, direction * distance, hit ? Color.green : Color.red);
        return hit;
    }

    private void Flip()
    {
        speed = -speed;
        transform.localScale = new Vector2(Direction, 1f);
    }
}