using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    Rigidbody2D enemyRB;
    Transform player;

    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        enemyRB.linearVelocity = new Vector2(player.position.x - transform.position.x, 0f).normalized * speed;
        transform.localScale = new Vector2(Mathf.Sign(enemyRB.linearVelocityX), 1.0f);
    }
}
