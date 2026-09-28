using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform gun;
    [SerializeField] float fireCooldown = 0.2f;

    PlayerHealth playerHealth;
    float nextFireTime;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnAttack(InputValue value)
    {
        if (!playerHealth.IsAlive) return;
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireCooldown;

        Bullet bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        bullet.Launch(Mathf.Sign(transform.localScale.x));
    }
}
