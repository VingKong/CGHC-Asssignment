using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Event raised when completing a level
    public static Action LoadNextLevel;

    public enum GameStates
    {
        GameStart,
        LevelLoaded,
        LevelCompleted
    }

    // The Current State of our Game
    public GameStates GameState { get; set; }

    // Stores the level completed index
    public int CurrentLevelCompleted { get; set; }

    protected override void Awake()
    {
        base.Awake();
        GameState = GameStates.GameStart;
    }

    // Response to the levelcompleted event

    private void LevelCompleted(int levelIndex)
    {
        CurrentLevelCompleted = levelIndex;
        GameState = GameStates.LevelCompleted;

        LoadNextLevel?.Invoke();
    }

    private void OnEnable()
    {
        CheckPoint.OnLevelCompleted += LevelCompleted;
    }

    private void OnDisable()
    {
        CheckPoint.OnLevelCompleted -= LevelCompleted;
    }
}
