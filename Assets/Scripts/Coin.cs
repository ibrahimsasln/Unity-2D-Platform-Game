using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;

    bool wasCollected = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !wasCollected)
        {
            wasCollected = true;

            PlayerMovement wallet = other.gameObject.GetComponent<PlayerMovement>();
            wallet.AddCoin();

            AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);
            Destroy(gameObject);
        }
    }
}
