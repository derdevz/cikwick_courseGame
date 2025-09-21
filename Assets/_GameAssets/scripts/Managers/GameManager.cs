using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("REFERENCES")]
    [SerializeField] private EggCounterUI _eggCounterUI;

    [Header("SETTİNGS")]
    [SerializeField] private int _maxEggCount = 5;

    private int _currentEggCount;

    private void Awake()
    {
        Instance = this;
    }

    public void OnEggCollected()
    {
        _currentEggCount++;
        _eggCounterUI.SetEggcounterText(_currentEggCount, _maxEggCount);

        if (_currentEggCount == _maxEggCount)
        {
            _eggCounterUI.SetEggCopleted();
        }
    }
}
