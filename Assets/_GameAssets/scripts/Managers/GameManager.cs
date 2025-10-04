using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<GameState> OnGameStateChanged;

    [Header("REFERENCES")]
    [SerializeField] private CatController _catController;
    [SerializeField] private EggCounterUI _eggCounterUI;
    [SerializeField] private WinLoseUI _winLoseUI;
    [SerializeField] private PlayerHealthUI _playerHealthUI;

    [Header("SETTINGS")]
    [SerializeField] private int _maxEggCount = 5;
    [SerializeField] private float _delay;

    private int _currentEggCount;
    private bool _isCatCatched;

    private GameState _currentGameState;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        HealthManager.Instance.OnPlayerDeath += HealthManager_OnPlayerDeath;
        _catController.OnCatCatched += CatController_OnCatCatched;
    }

    private void CatController_OnCatCatched()
    {
        if (!_isCatCatched)
        {
            _playerHealthUI.AnimateDamageForAll();
            StartCoroutine(OnGameOver());
            CameraShake.Instance.ShakeCamera(1.7f, 2f, 0.4f);
            _isCatCatched = true;
        }
    }

    private void HealthManager_OnPlayerDeath()
    {
        StartCoroutine(OnGameOver());
    }

    private void OnEnable()
    {
        ChangedGameStated(GameState.CutScene);
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

    private IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(_delay);
        ChangedGameStated(GameState.Gameover);
        _winLoseUI.OnGameLose();
    }

    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    }
}
