using System.Collections.Generic;
using UnityEngine;

using static AllEnums;

public class PlayerInventory : MonoBehaviour
{
    public int maxSkillSlots = 5;
    public List<GameObject> attackSlots;
    public List<GameObject> attributeSlots;
    public List<GameObject> starterSlots;

    void Awake()
    {
        attackSlots = new();
        attributeSlots = new();
        starterSlots = new();
    }

    public bool AddAttackSkill(AttackStatsScriptableObject newAttackStats)
    {
        // Check if already owned

        // Add new skill if there's room
        if (attackSlots.Count < maxSkillSlots)
        {
            GameObject skillObj = new(newAttackStats.AttackName);
            skillObj.transform.parent = transform;
            
            AttackStats atkStatsInstance = skillObj.AddComponent<AttackStats>();
            atkStatsInstance.AtkStats = newAttackStats;

            attackSlots.Add(skillObj);
            return true;
        }

        // Inventory full
        return false;
    }

    void Update()
    {

    }
}
