using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelingUI : MonoBehaviour
{
    [SerializeField] private GameObject skillOptionPrefab;
    [SerializeField] private Transform skillOptionsListPanel;
    [SerializeField] private ShowSkillDescription skillDescriptionPanel;
    private bool isChoosingSkill = false;

    public void ShowSkillOptions(List<SkillStatsScriptableObject> skills)
    {
        if (isChoosingSkill) return;

        // Clear old
        foreach (Transform child in skillOptionsListPanel)
        {
            Destroy(child.gameObject);
        }
        skillDescriptionPanel.HideDescription();

        foreach (SkillStatsScriptableObject skill in skills)
        {
            GameObject optionInstance = Instantiate(skillOptionPrefab, skillOptionsListPanel);

            optionInstance.GetComponent<SkillOptionUI>().Initialize(skill, skillDescriptionPanel);

            Button button = optionInstance.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                PlayerManager.Instance.PlayerInventory.AddSkill(skill);
                gameObject.SetActive(false);
                isChoosingSkill = false;
                Time.timeScale = 1f;
            });
        }

        gameObject.SetActive(true);
        isChoosingSkill = true;
        Time.timeScale = 0f;
    }
}
