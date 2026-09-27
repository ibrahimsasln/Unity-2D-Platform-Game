using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5.0f;
    [SerializeField] float bulletLifeTime = 2.0f;
    bool isDead = false;
    Rigidbody2D bulletRB;
    Player player;
    CoinDropper dropper;
    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<Player>();
        dropper = FindFirstObjectByType<CoinDropper>();
        bulletRB.linearVelocityX = player.transform.localScale.x * bulletSpeed;
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isDead)
        {
            isDead = true;
            dropper.CoinDrop(other.transform);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
