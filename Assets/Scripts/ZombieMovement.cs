using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    Rigidbody2D zombieRB;
    Transform player;

    private void Awake()
    {
        zombieRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        zombieRB.linearVelocity = new Vector2(player.position.x - transform.position.x, 0f).normalized * speed;
        transform.localScale = new Vector2(Mathf.Sign(zombieRB.linearVelocityX), 1.0f);
    }
}
