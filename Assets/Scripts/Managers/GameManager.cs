using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3;

    public static GameManager Instance { get; private set; }

    public int Coins { get; private set; }
    public event Action<int> CoinsChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        CoinsChanged?.Invoke(Coins);
    }

    public void HandlePlayerDeath()
    {
        if (playerLives > 1)
        {
            LoseLife();
        }
        else
        {
            GameOver();
        }
    }

    private void LoseLife()
    {
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        // shows Game Over screen and restart button or main menu button
    }
}
