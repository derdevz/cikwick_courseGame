using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<GameState> OnGameStateChanged;

    [Header("REFERENCES")]
    [SerializeField] private EggCounterUI _eggCounterUI;
    [SerializeField] private WinLoseUI _winLoseUI;

    [Header("SETTİNGS")]
    [SerializeField] private int _maxEggCount = 5;

    private int _currentEggCount;

    private GameState _currentGameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Onable()
    {
        ChangedGameStated(GameState.Play);
    }

    public void ChangedGameStated(GameState gameState)
    {
        OnGameStateChanged?.Invoke(gameState);
        _currentGameState = gameState;
    }

    public void OnEggCollected()
    {
        _currentEggCount++;
        _eggCounterUI.SetEggcounterText(_currentEggCount, _maxEggCount);

        if (_currentEggCount == _maxEggCount)
        {
            _eggCounterUI.SetEggCopleted();
            ChangedGameStated(GameState.Gameover);
            _winLoseUI.OnGameWin();
        }
    }

    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    }
}
