using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int coinCount;

    public void CoinDrop(Transform enemyTransform)
    {
        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, enemyTransform.position, Quaternion.identity);
            Rigidbody2D coinRB = coin.GetComponent<Rigidbody2D>();

            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
            coinRB.AddForce(dropDirection * Random.Range(3f, 6f), ForceMode2D.Impulse);
        }
    }
}
