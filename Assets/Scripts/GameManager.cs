using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3;

    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerDeathProcess()
    {
        if(playerLives > 1)
        {
            ReduceLive();
        }
        else
        {
            GameOver();
        }
    }

    private void ReduceLive()
    {
        throw new NotImplementedException();
    }

    private void GameOver()
    {
        // shows Game Over screen and restart button or main menu button 
    }
}
