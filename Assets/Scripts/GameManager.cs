using UnityEditor;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private UIController uiController;
    [SerializeField] private LevelController levelController;
    [SerializeField] private PlayerStats playerStats;

    private float _progressValue;

    private void Start()
    {
        uiController.SetHealth(playerStats.GetHealth());
        uiController.UpdateSpeed(playerStats.speed);
    }

    public void UpdateLevel()
    {
        _progressValue++;
        playerStats.IncreaseSpeed();
        uiController.UpdateProgress(_progressValue);
        uiController.UpdateSpeed(playerStats.speed);
        
        levelController.MoveLevel();
    }

    public void SetDamage(float damage)
    {
        playerStats.SetDamage(damage);
        playerStats.DecreaseSpeed();
        uiController.UpdateSpeed(playerStats.speed);
        
        float health = playerStats.GetHealth();
        uiController.SetHealth(health);
        
        if (health > 0) return;
        
        LoseGame();
    }

    public void LoseGame()
    {
        EditorApplication.isPaused = true;
    }
}
