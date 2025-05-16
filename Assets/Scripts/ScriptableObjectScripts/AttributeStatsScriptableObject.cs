using UnityEngine;
using static AllEnums;

[CreateAssetMenu(fileName ="AttributeStatsScriptableObject", menuName ="ScriptableObjects/Attribute")]
public class AttributeStatsScriptableObject : SkillStatsScriptableObject
{
    [SerializeField]
    private float multiplier;
    public float Multiplier { get => multiplier; private set => multiplier = value; }

    [SerializeField]
    private AttributeType attributeType;
    public AttributeType AttributeType { get => attributeType; private set => attributeType = value; }
}
