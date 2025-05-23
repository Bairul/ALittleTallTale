using TMPro;
using UnityEngine;

public class ShowSkillDescription : MonoBehaviour
{
    public TMP_Text descriptionText;

    public void ShowDescription(string desc)
    {
        descriptionText.text = desc;
    }

    public void HideDescription()
    {
        descriptionText.text = "Choose a Skill";
    }
}
