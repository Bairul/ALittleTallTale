using UnityEngine;
using static AllEnums;

public class SkillStatsScriptableObject : ScriptableObject
{
    [SerializeField]
    private string skillName;
    public string SkillName { get => skillName; private set => skillName = value; }

    [SerializeField]
    private string skillDescription;
    public string SkillDescription { get => skillDescription; private set => skillDescription = value; }

    [SerializeField]
    private SkillType skillType;
    public SkillType SkillType { get => skillType; private set => skillType = value; }

    [SerializeField]
    private Sprite skillIcon;
    public Sprite SkillIcon { get => skillIcon; private set => skillIcon = value; }
}
