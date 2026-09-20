using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    Rigidbody2D zombieRB;
    Transform playerTransform;
    PlayerMovement playerMovement;

    private void Awake()
    {
        zombieRB = GetComponent<Rigidbody2D>();
        
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        playerTransform = playerMovement.transform;
    }

    private void FixedUpdate()
    {
        if (!playerMovement.IsPlayerAlive)
        {
            zombieRB.linearVelocity = Vector2.zero;
            return;
        }
        zombieRB.linearVelocity = new Vector2(playerTransform.position.x - transform.position.x, 0f).normalized * speed;
        transform.localScale = new Vector2(Mathf.Sign(zombieRB.linearVelocityX), 1.0f);
    }
}
