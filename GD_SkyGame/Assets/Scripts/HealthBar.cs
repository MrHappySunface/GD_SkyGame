using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private RectTransform _barRect;
    [SerializeField] private RectMask2D _mask;

    private float _maxWidth;

    private void Start()
    {
        _maxWidth = _barRect.rect.width;
        UpdateUI(_health.Hp);
    }

    public void SetValue(int newValue)
    {
        UpdateUI(newValue);
    }

    private void UpdateUI(int currentHp)
    {
        float hpPercent = Mathf.Clamp01((float)currentHp / _health.MaxHp);
        float newRightPadding = _maxWidth * (1f - hpPercent);

        Vector4 padding = _mask.padding;
        padding.z = newRightPadding;
        _mask.padding = padding;
    }
}