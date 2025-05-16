using System.Collections.Generic;
using UnityEngine;

using static AllEnums;

public class PlayerInventory : MonoBehaviour
{
    public int maxSkillSlots = 5;
    public List<GameObject> attackSlots;
    public List<GameObject> attributeSlots;
    public List<GameObject> starterSlots;

    public List<WeightedObject> availableSkills;
    private PlayerStats playerStats;

    void Awake()
    {
        attackSlots = new();
        attributeSlots = new();
        starterSlots = new();
    }

    /// <summary>
    /// Character’s elemental affinity defines the skill pool <br></br>
    /// Ex. If a character has Fire and Water affinity, then their Skill pool will consist of Fire and Water type skills. <br></br>
    /// Character’s bloodline skills (basic, unique) are also added to the pool at the start. <br></br>
    /// Character’s passive can add or remove certain skills in the pool at the start. <br></br>
    /// Includes all attribute/supporting skills (%Atk, %Hp, %Mvt, etc) 
    /// </summary>
    void Start()
    {
        playerStats = GetComponentInParent<PlayerStats>();

        ElementalType[] elementalAffinities = playerStats.CharStats.ElementalAffinities;
        availableSkills = new List<WeightedObject>();

        foreach (AttackStatsScriptableObject skill in GameWorld.Instance.AllAttackSkills) {
            foreach (ElementalType playerElementalType in elementalAffinities) {
                if (skill.ElementalType == playerElementalType) {
                    availableSkills.Add(new WeightedObject(skill, 1));
                }
            }
        }

        // add attribues
        foreach (AttributeStatsScriptableObject skill in GameWorld.Instance.AllAttributeSkills)
        {
            availableSkills.Add(new WeightedObject(skill, 1));
        }

        // add bloodline here
    }

    List<WeightedObject> CopyOfAvailableSkills()
    {
        List<WeightedObject> copy = new();
        foreach (WeightedObject weightedObject in availableSkills)
        {
            copy.Add(new WeightedObject(weightedObject.prefab, weightedObject.weight));
        }
        return copy;
    }

    /// <summary>
    /// Player can choose from 3 or 4 skills after leveling <br></br>
    /// Each skill must be unique <br></br>
    /// Each skill is chosen based on weights
    /// </summary>
    /// <param name="length"> How many skills to choose from</param>
    /// <returns></returns>
    public List<SkillStatsScriptableObject> GetSkills(int length)
    {
        List<SkillStatsScriptableObject> skills = new();
        List<WeightedObject> copy = CopyOfAvailableSkills();

        for (int i = 0; i < length; i++)
        {
            WeightedObject obj = WeightedObject.GetRandomWeightedObject(copy);

            if (obj != null && obj.prefab != null)
            {
                copy.Remove(obj);
                WeightedObject.NormalizeWeights(copy);
                Debug.Log(obj.prefab.SkillName);

                skills.Add(obj.prefab);
            }
        }

        return skills;
    }

    /// <summary>
    /// Character’s weapon affects the weights of the skills in the pool <br></br>
    /// Ex. Increase/decrease the chance of getting a Fire type skill by 25% <br></br>
    /// Ex. Increase/decrease the chance of getting Fireball skill by 50% <br></br>
    /// Weights may be affected during runtime from artifacts or debuffs
    /// </summary>
    /// <param name="type"></param>
    /// <param name="percentageChange"></param>
    public void AdjustWeightOfType(ElementalType type, float percentageChange)
    {
        foreach (WeightedObject weightedObject in availableSkills)
        {
            if (weightedObject.prefab.SkillType == SkillType.Elemental) {
                if (((AttackStatsScriptableObject) weightedObject.prefab).ElementalType == type)
                {
                    weightedObject.weight *= percentageChange;
                }
            }
        }

        WeightedObject.NormalizeWeights(availableSkills);
    }

    public void AdjustWeightOfSkill(string skillName, float percentageChange)
    {
        foreach (WeightedObject weightedObject in availableSkills)
        {
            if (weightedObject.prefab.SkillName.Equals(skillName))
            {
                weightedObject.weight *= percentageChange;
            }
        }

        WeightedObject.NormalizeWeights(availableSkills);
    }

    public bool AddSkill(SkillStatsScriptableObject skill)
    {
        // Check if already owned

        // Add new skill if there's room
        if (skill.SkillType == SkillType.Elemental)
        {
            if (attackSlots.Count < maxSkillSlots)
            {
                AttackStatsScriptableObject attackSkill = (AttackStatsScriptableObject) skill;

                GameObject skillObj = new(attackSkill.SkillName);
                skillObj.transform.SetParent(transform, worldPositionStays: false);
                
                AttackStats atkStatsInstance = skillObj.AddComponent<AttackStats>();
                atkStatsInstance.AtkStats = attackSkill;

                attackSlots.Add(skillObj);
                return true;
            }
        }
        else if (skill.SkillType == SkillType.Attribue)
        {
            if (attributeSlots.Count < maxSkillSlots)
            {
                AttributeStatsScriptableObject attributeSkill = (AttributeStatsScriptableObject) skill;

                GameObject skillObj = new(attributeSkill.SkillName);
                skillObj.transform.SetParent(transform, worldPositionStays: false);
                
                AttributeStats atriStatsInstance = skillObj.AddComponent<AttributeStats>();
                atriStatsInstance.AttriStats = attributeSkill;
                atriStatsInstance.PlayerStats = playerStats;

                attributeSlots.Add(skillObj);
                return true;
            }
        }

        // Inventory full
        return false;
    }

    void Update()
    {
        // testing only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddSkill(GetSkills(1)[0]);
        }
    }
}
