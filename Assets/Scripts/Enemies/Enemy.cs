using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int contactDamage = 1;
    [SerializeField] int coinDropCount = 3;

    Health health;
    CoinDropper coinDropper;

    private void Awake()
    {
        health = GetComponent<Health>();
        coinDropper = FindFirstObjectByType<CoinDropper>();
    }

    private void OnEnable()
    {
        health.Died += OnDied;
    }

    private void OnDisable()
    {
        health.Died -= OnDied;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (health.IsDead || !collision.gameObject.CompareTag("Player")) return;

        if (collision.gameObject.TryGetComponent(out Health playerHealth))
        {
            playerHealth.TakeDamage(contactDamage, transform.position);
        }
    }

    private void OnDied()
    {
        coinDropper.DropCoins(transform.position, coinDropCount);
        Destroy(gameObject);
    }
}
