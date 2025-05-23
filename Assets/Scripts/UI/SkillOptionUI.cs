using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillOptionUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SkillStatsScriptableObject skill;
    private ShowSkillDescription descriptionPanel;

    public void Initialize(SkillStatsScriptableObject skill, ShowSkillDescription descPanel)
    {
        this.skill = skill;
        descriptionPanel = descPanel;

        transform.Find("Icon").GetComponent<Image>().sprite = skill.SkillIcon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.ShowDescription(skill.SkillDescription);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.HideDescription();
    }
}
