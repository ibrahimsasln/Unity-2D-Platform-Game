using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int coinDropCount = 3;

    CoinDropper coinDropper;
    bool isDead;

    private void Awake()
    {
        coinDropper = FindFirstObjectByType<CoinDropper>();
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        coinDropper.DropCoins(transform.position, coinDropCount);
        Destroy(gameObject);
    }
}
