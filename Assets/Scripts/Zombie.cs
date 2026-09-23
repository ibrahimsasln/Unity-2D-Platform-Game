using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;

    Rigidbody2D zombieRB;
    Transform playerTransform;
    Player player;

    private void Awake()
    {
        zombieRB = GetComponent<Rigidbody2D>();

        player = FindFirstObjectByType<Player>();
        playerTransform = player.transform;
    }

    private void FixedUpdate()
    {
        if (!player.IsPlayerAlive)
        {
            zombieRB.linearVelocity = Vector2.zero;
            return;
        }
        zombieRB.linearVelocity = new Vector2(playerTransform.position.x - transform.position.x, 0f).normalized * speed;
        transform.localScale = new Vector2(Mathf.Sign(zombieRB.linearVelocityX), 1.0f);
    }
}
