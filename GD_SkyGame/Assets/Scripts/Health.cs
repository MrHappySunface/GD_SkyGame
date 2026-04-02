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
            _hp = Mathf.Clamp(value, 0, _maxHp);
            if (isDamage)
            {
                Damaged?.Invoke(_hp);
            }

            if (_hp <= 0)
            {
                Died?.Invoke();
            }
        }
    }

    public UnityEvent<int> Damaged;
    public UnityEvent Died;

    private void Awake()
    {
        _hp = _maxHp;
    }

    public void Damage(int amount) => Hp -= amount;
    public void Kill() => Hp = 0;
    public void Adjust(int value) => Hp = value;
}
