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
            AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);
            Destroy(gameObject);
        }
    }
}
