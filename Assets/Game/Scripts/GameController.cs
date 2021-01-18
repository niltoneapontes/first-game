using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private bool isGameRunning;
    private int score;
    private int currentLevelIndex;

    public ObstacleGenerator generator;
    public GameConfiguration config;
    public TextMeshProUGUI scoreLabel;
    public GameUI gameStartUI;
    public GameUI gameOverUI;
    public Player player;
    public LevelConfiguration[] levels;

    void Start()
    {
        currentLevelIndex = 0;
        isGameRunning = false;
        generator.StopGenerator();
        gameStartUI.Show();
    }

    private void Update()
    {
        scoreLabel.text = score.ToString("000000000.##");

        if(!isGameRunning) return;
        score++;
        CheckLevelUpdate();
    }

    private void CheckLevelUpdate()
    {
        if(currentLevelIndex >= levels.Length - 1) return;
        if(score < levels[currentLevelIndex + 1].minScore) return;
        currentLevelIndex++;
        print(currentLevelIndex);
        SetCurrentLevelConfiguration();
    }

    private void SetCurrentLevelConfiguration()
    {
        LevelConfiguration level = levels[currentLevelIndex];
        config.speed = level.speed;
        config.minRangeObstacleGenerator = level.minRangeObstacleGenerator;
        config.maxRangeObstacleGenerator = level.maxRangeObstacleGenerator;
    }

    public void GameStart()
    {
        isGameRunning = true;   
        currentLevelIndex = 0;
        SetCurrentLevelConfiguration();

        score = 0;
        generator.GenerateObstacles();
        gameStartUI.Hide();
        player.SetActive();
    }
    
    public void GameOver()
    {
        isGameRunning = false;

        config.speed = 0f;
        generator.StopGenerator();
        gameOverUI.Show();
    }

    public void RestartGame()
    {
        gameOverUI.Hide();
        generator.ResetGenerator();
        GameStart();
    }
}
