using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] private RectTransform barRectFill;
    [SerializeField] private RectMask2D mask;

    [SerializeField] private bool isMirrored;

    private float maxMask;
    private float initialMask;

    void Start()
    {
        maxMask = barRectFill.rect.width - mask.padding.x - mask.padding.z;
        initialMask = isMirrored ? mask.padding.x : mask.padding.z;
    }

    public void SetValue(float currentValue, float maxValue)
    {
        float healthPercent = Mathf.Clamp01(currentValue / maxValue);
        float newMask = (1f - healthPercent) * maxMask + initialMask;

        var padding = mask.padding;
        if (isMirrored) padding.x = newMask;
        else padding.z = newMask;
        mask.padding = padding;
    }
}
