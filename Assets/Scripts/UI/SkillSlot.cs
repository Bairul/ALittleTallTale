using UnityEngine;
using UnityEngine.UI;

public class SkillSlotUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Image cooldownFillImage;

    private AttackStats attackStats;
    private bool hasCooldown;

    public void Initialize(AttackStats attackStats)
    {
        this.attackStats = attackStats;
        iconImage.sprite = attackStats.AtkStats.SkillIcon;
        hasCooldown = true;
    }

    public void Initialize(AttributeStats attributeStats)
    {
        iconImage.sprite = attributeStats.AttriStats.SkillIcon;
        hasCooldown = false;
        cooldownFillImage.fillAmount = 0f;
    }

    void LateUpdate()
    {
        if (!hasCooldown || attackStats == null) return;

        float current = attackStats.currentCooldown;
        float max = attackStats.AtkStats.AttackCooldown;
        float fill = Mathf.Clamp01(current / max);
        cooldownFillImage.fillAmount = fill;
    }
}