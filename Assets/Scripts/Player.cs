using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    static readonly int DyingHash = Animator.StringToHash("Dying");

    [SerializeField] float deathBounce = 10f;
    [SerializeField] float deathDelay = 2f;

    Rigidbody2D playerRB;
    Animator playerAnimator;
    LayerMask enemiesLayer;

    public bool IsAlive { get; private set; } = true;
    public event Action Died;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        enemiesLayer = LayerMask.GetMask("Enemies");
    }

    private void FixedUpdate()
    {
        if (IsAlive && playerRB.IsTouchingLayers(enemiesLayer))
        {
            Die();
        }
    }

    private void Die()
    {
        IsAlive = false;
        playerAnimator.SetTrigger(DyingHash);
        playerRB.linearVelocityY = deathBounce;

        Died?.Invoke();
        StartCoroutine(ReportDeathAfterDelay());
    }

    private IEnumerator ReportDeathAfterDelay()
    {
        yield return new WaitForSeconds(deathDelay);
        GameManager.Instance.HandlePlayerDeath();
    }
}
