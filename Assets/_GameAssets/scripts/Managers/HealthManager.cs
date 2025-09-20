using System.Data;
using UnityEngine;
public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Damage(int damageAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth = _maxHealth - damageAmount;
            // TODO:UI ANİMATE DAMAGE
            
            if (_currentHealth <= 0)
            {
                // TODO:Player DEAD
            }
        }
    }

    public void Heal(int healamount)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.Min(_currentHealth + healamount, _maxHealth);
        }
    }
}