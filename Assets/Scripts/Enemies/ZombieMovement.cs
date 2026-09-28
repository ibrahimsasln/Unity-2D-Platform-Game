using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    Rigidbody2D zombieRB;
    PlayerHealth player;

    private void Awake()
    {
        zombieRB = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if (!player.IsAlive)
        {
            zombieRB.linearVelocityX = 0f;
            return;
        }

        float direction = Mathf.Sign(player.transform.position.x - transform.position.x);
        zombieRB.linearVelocityX = direction * speed;
        transform.localScale = new Vector2(direction, 1f);
    }
}
