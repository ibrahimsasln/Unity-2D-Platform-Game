using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    Rigidbody2D zombieRB;
    GameObject player;
    PlayerMovement playerMovement;

    private void Awake()
    {
        zombieRB = GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (!playerMovement.IsPlayerAlive)
        {
            zombieRB.linearVelocity = Vector2.zero;
            return;
        }
        zombieRB.linearVelocity = new Vector2(player.transform.position.x - transform.position.x, 0f).normalized * speed;
        transform.localScale = new Vector2(Mathf.Sign(zombieRB.linearVelocityX), 1.0f);
    }
}
