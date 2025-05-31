using UnityEngine;
using UnityEngine.UI;

public class StatBarAnimated : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private Sprite[] barFrames; // Ordered from empty to full

    private int frameCount;

    void Awake()
    {
        frameCount = barFrames.Length;
    }

    public void SetValue(float currentValue, float maxValue)
    {
        float percent = Mathf.Clamp01(currentValue / maxValue);

        int frameIndex = (int) Mathf.RoundToInt(percent * (frameCount - 1));

        barImage.sprite = barFrames[frameIndex];
    }
}