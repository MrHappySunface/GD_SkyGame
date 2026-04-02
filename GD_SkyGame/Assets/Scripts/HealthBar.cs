using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private RectTransform _barRect;
    [SerializeField] private RectMask2D _mask;

    private float _paddingRatio;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();

        _paddingRatio = 293f / _barRect.rect.width;
        UpdateUI(_health.Hp);
    }

    public void SetValue(int newValue)
    {
        UpdateUI(newValue);
    }

    private void UpdateUI(int currentHp)
    {
        float hpPercent = Mathf.Clamp01((float)currentHp / _health.MaxHp);

        // Dynamically calculate the right padding for any resolution
        float currentFullPadding = _barRect.rect.width * _paddingRatio;
        float targetPadding = currentFullPadding * (1f - hpPercent);

        Vector4 padding = _mask.padding;
        padding.z = targetPadding;
        _mask.padding = padding;
    }


}