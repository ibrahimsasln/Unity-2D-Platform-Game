using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] float invulnerabilityDuration = 0f;

    float invulnerableUntil;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => maxHealth;
    public bool IsDead { get; private set; }

    public event Action<int, int> HealthChanged;
    public event Action<Vector2> Damaged;
    public event Action Died;

    bool IsInvulnerable => Time.time < invulnerableUntil;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int amount, Vector2 hitFrom)
    {
        if (IsDead || IsInvulnerable) return;

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
        invulnerableUntil = Time.time + invulnerabilityDuration;
        HealthChanged?.Invoke(CurrentHealth, maxHealth);

        if (CurrentHealth == 0)
        {
            IsDead = true;
            Died?.Invoke();
        }
        else
        {
            Damaged?.Invoke(hitFrom);
        }
    }
}
