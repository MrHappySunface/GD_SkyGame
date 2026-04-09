using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHp = 100;
    private int _hp;

    public int MaxHp => _maxHp;

    public int Hp
    {
        get => _hp;
        private set
        {
            var isDamage = value < _hp;
            var isHeal = value > _hp;

            _hp = Mathf.Clamp(value, 0, _maxHp);
            
            if (isDamage) Damaged?.Invoke(_hp);
            if (isHeal) Healed?.Invoke(_hp);
        }
    }

    public UnityEvent<int> Damaged;
    public UnityEvent<int> Healed;

    private void OnEnable()
    {
        _hp = _maxHp;
    }

    public void Damage(int amount)
    {
        Hp -= amount;
        Debug.Log($"Taking Damage. Current HP: {_hp}");
        
    }
    public void Heal(int amount)
    {
        Hp += amount;
        Debug.Log($"Healing. Current HP: {_hp}");
        
    }
    public void Kill() => Hp = 0;
    public void Adjust(int value) => Hp = value;
}
