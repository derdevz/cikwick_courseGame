using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesignSO", menuName = "ScriptbleObject/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] float _increaseDecreaseMultiplier;
    [SerializeField] float _resetBoostDuration;
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _passiveSprite;
    [SerializeField] private Sprite _activeWheatSprite;
    [SerializeField] private Sprite _passiveWheatSprite;

    public float IncreaseDecreaseMultiplier => _increaseDecreaseMultiplier;
    public float ResetBoostDuration => _resetBoostDuration;

    public Sprite ActiveSprite => _activeSprite;
    public Sprite PasssiveSprite => _passiveSprite;
    public Sprite ActiveWheatSprite => _activeWheatSprite;
    public Sprite PassiveWheatSprite => _passiveWheatSprite;
}
