using System.Collections.Generic;
using UnityEngine;
using static AllEnums;

public class PlayerSkillPool : MonoBehaviour
{
    private List<WeightedObject> availableSkills;
    public List<WeightedObject> AvailableSkills { get => availableSkills; private set => availableSkills = value; }

    void Awake()
    {
        availableSkills = new List<WeightedObject>();
    }

    /// <summary>
    /// Character’s elemental affinity defines the skill pool <br></br>
    /// Ex. If a character has Fire and Water affinity, then their Skill pool will consist of Fire and Water type skills. <br></br>
    /// Character’s bloodline skills (basic, unique) are also added to the pool at the start. <br></br>
    /// Character’s passive can add or remove certain skills in the pool at the start. <br></br>
    /// Includes all attribute/supporting skills (%Atk, %Hp, %Mvt, etc) 
    /// </summary>
    public void Initialize(ElementalType[] elementalAffinities)
    {
        foreach (AttackStatsScriptableObject skill in GameWorld.Instance.AllAttackSkills)
        {
            foreach (ElementalType playerElementalType in elementalAffinities)
            {
                if (skill.ElementalType == playerElementalType)
                {
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
            copy.Add(new WeightedObject(weightedObject.item, weightedObject.weight));
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
    public List<SkillStatsScriptableObject> OfferRandomSkills(int length)
    {
        List<SkillStatsScriptableObject> skills = new();
        List<WeightedObject> copy = CopyOfAvailableSkills();

        for (int i = 0; i < length; i++)
        {
            WeightedObject obj = WeightedObject.GetRandomWeightedObject(copy);

            if (obj != null && obj.item != null)
            {
                copy.Remove(obj);
                WeightedObject.NormalizeWeights(copy);

                SkillStatsScriptableObject skill = (SkillStatsScriptableObject) obj.item;
                skills.Add(skill);
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
            if (((SkillStatsScriptableObject) weightedObject.item).SkillType == SkillType.Elemental) {
                if (((AttackStatsScriptableObject) weightedObject.item).ElementalType == type)
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
            if (((SkillStatsScriptableObject) weightedObject.item).SkillName.Equals(skillName))
            {
                weightedObject.weight *= percentageChange;
            }
        }

        WeightedObject.NormalizeWeights(availableSkills);
    }
}
