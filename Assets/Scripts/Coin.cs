using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;

    bool wasCollected;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (wasCollected || !other.gameObject.CompareTag("Player")) return;
        wasCollected = true;

        GameManager.Instance.AddCoins(1);
        AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);
        Destroy(gameObject);
    }
}
