using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesignSO", menuName = "ScriptbleObject/WheatDesignSO")]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] float _increaseDecreaseMultiplier;
    [SerializeField] float _resetBoostDuration;

    public float IncreaseDecreaseMultiplier => _increaseDecreaseMultiplier;
    public float ResetBoosetDuration => _resetBoostDuration;
}
