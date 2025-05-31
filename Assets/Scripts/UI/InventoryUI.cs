using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform attackListPanel;
    [SerializeField] private Transform attributeListPanel;

    public void AddAttackSlot(AttackStats attackStats)
    {
        GameObject slotInstance = Instantiate(slotPrefab, attackListPanel);
        slotInstance.GetComponent<SkillSlotUI>().Initialize(attackStats);
    }

    public void AddAttributeSlot(AttributeStats attributeStats)
    {
        GameObject slotInstance = Instantiate(slotPrefab, attributeListPanel);
        slotInstance.GetComponent<SkillSlotUI>().Initialize(attributeStats);
    }
}
