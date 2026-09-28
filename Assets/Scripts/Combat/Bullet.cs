using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] float bulletLifeTime = 1f;

    bool hasHit;

    public void Launch(float direction)
    {
        GetComponent<Rigidbody2D>().linearVelocityX = direction * bulletSpeed;
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;
        hasHit = true;

        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
        }
        Destroy(gameObject);
    }
}
