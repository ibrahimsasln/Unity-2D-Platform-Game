using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5.0f;
    Rigidbody2D bulletRB;
    PlayerMovement player;
    float xSpeed;
    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        bulletRB.linearVelocityX = player.transform.localScale.x * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
