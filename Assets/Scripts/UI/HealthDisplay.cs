using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    Health playerHealth;

    private void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    private void OnEnable()
    {
        playerHealth.HealthChanged += UpdateText;
    }

    private void OnDisable()
    {
        playerHealth.HealthChanged -= UpdateText;
    }

    private void Start()
    {
        UpdateText(playerHealth.CurrentHealth, playerHealth.MaxHealth);
    }

    private void UpdateText(int current, int max)
    {
        healthText.text = $"HP {current}/{max}";
    }
}
