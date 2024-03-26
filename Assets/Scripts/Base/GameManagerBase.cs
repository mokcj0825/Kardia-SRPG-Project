using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBase : MonoBehaviourBase
{
    public enum GameState { Start, PlayerTurn, EnemyTurn, Win, Lose }
    public GameState state;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        InitializeGame();
    }

    // Initializes the game, setting the initial state and configuring any necessary settings
    protected virtual void InitializeGame()
    {
        // Set the initial game state, such as loading levels, setting up players/enemies, etc.
        ChangeState(GameState.Start);
    }

    // Updates the game manager each frame. Could be used to check for win/lose conditions dynamically.
    protected override void Update()
    {
        base.Update();

        // Example: Check for win/lose conditions or other state transitions here
    }

    // Changes the current game state to a new state
    public void ChangeState(GameState newState)
    {
        state = newState;
        OnStateChanged(state);
    }

    // Handles actions to be taken when the game state changes
    protected virtual void OnStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                // Initialize game start conditions
                OnGameStart();
                break;
            case GameState.PlayerTurn:
                // Handle beginning of player's turn
                OnPlayerTurnStart();
                break;
            case GameState.EnemyTurn:
                // Handle beginning of enemy's turn
                OnEnemyTurnStart();
                break;
            case GameState.Win:
                // Handle win condition
                OnGameWin();
                break;
            case GameState.Lose:
                // Handle lose condition
                OnGameLose();
                break;
        }
    }

    // Optional: Implement custom logic for when the game starts
    protected virtual void OnGameStart()
    {
        // Implement game start logic, such as setting up the game board or units
    }

    // Optional: Implement custom logic for when the player's turn starts
    protected virtual void OnPlayerTurnStart()
    {
        // Implement player turn start logic
    }

    // Optional: Implement custom logic for when the enemy's turn starts
    protected virtual void OnEnemyTurnStart()
    {
        // Implement enemy turn start logic
    }

    // Optional: Implement custom logic for when the game is won
    protected virtual void OnGameWin()
    {
        // Implement win logic, such as displaying win messages or animations
    }

    // Optional: Implement custom logic for when the game is lost
    protected virtual void OnGameLose()
    {
        // Implement lose logic, such as displaying lose messages or animations
    }

    // Call this method to check for win conditions - could be called from Update or specific actions
    public virtual void CheckWinConditions()
    {
        // Implement checks for win conditions and call ChangeState(GameState.Win) if met
    }

    // Call this method to check for lose conditions
    public virtual void CheckLoseConditions()
    {
        // Implement checks for lose conditions and call ChangeState(GameState.Lose) if met
    }
}