using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Image barFillImage;

    public void SetValue(float currentValue, float maxValue)
    {
        barFillImage.fillAmount = Mathf.Clamp01(currentValue / maxValue);
    }
}