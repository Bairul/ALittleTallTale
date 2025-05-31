using System.Collections.Generic;
using UnityEngine;

using static AllEnums;

public class PlayerInventory : MonoBehaviour
{
    public int maxSkillSlots = 5;
    public List<GameObject> attackSlots;
    public List<GameObject> attributeSlots;

    private PlayerStats playerStats;

    void Awake()
    {
        attackSlots = new();
        attributeSlots = new();
    }

    void Start()
    {
        playerStats = GetComponentInParent<PlayerStats>();

        InitBasicSkill((AttackStatsScriptableObject)playerStats.CharStats.BasicAttack);
    }

    private void InitBasicSkill(AttackStatsScriptableObject skill)
    {
        GameObject skillObj = new(skill.SkillName);
        skillObj.transform.SetParent(transform, worldPositionStays: false);

        AttackStats atkStatsInstance = skillObj.AddComponent<AttackStats>();
        atkStatsInstance.AtkStats = skill;

        skillObj.AddComponent<BasicSkillSlot>().Initialize(playerStats.PlayerUI.basicBar, atkStatsInstance);
    }

    public void AddSkill(SkillStatsScriptableObject skill)
    {
        // Check if already owned

        // Add new skill if there's room
        if (skill.SkillType == SkillType.Elemental)
        {
            if (attackSlots.Count < maxSkillSlots)
            {
                AttackStatsScriptableObject attackSkill = (AttackStatsScriptableObject)skill;

                GameObject skillObj = new(attackSkill.SkillName);
                skillObj.transform.SetParent(transform, worldPositionStays: false);

                AttackStats atkStatsInstance = skillObj.AddComponent<AttackStats>();
                atkStatsInstance.AtkStats = attackSkill;

                attackSlots.Add(skillObj);
                playerStats.PlayerUI.inventoryUI.AddAttackSlot(atkStatsInstance);
            }
        }
        else if (skill.SkillType == SkillType.Attribute)
        {
            if (attributeSlots.Count < maxSkillSlots)
            {
                AttributeStatsScriptableObject attributeSkill = (AttributeStatsScriptableObject)skill;

                GameObject skillObj = new(attributeSkill.SkillName);
                skillObj.transform.SetParent(transform, worldPositionStays: false);

                AttributeStats attriStatsInstance = skillObj.AddComponent<AttributeStats>();
                attriStatsInstance.AttriStats = attributeSkill;
                attriStatsInstance.PlayerStats = playerStats;

                attributeSlots.Add(skillObj);
                playerStats.PlayerUI.inventoryUI.AddAttributeSlot(attriStatsInstance);
            }
        }
    }
}
