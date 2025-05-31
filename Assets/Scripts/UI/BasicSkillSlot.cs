using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkillSlot : MonoBehaviour
{
    private StatBarAnimated basicBar;
    private AttackStats attackStats;

    public void Initialize(StatBarAnimated basicBar, AttackStats attackStats)
    {
        this.basicBar = basicBar;
        this.attackStats = attackStats;
    }

    void LateUpdate()
    {
        basicBar.SetValue(attackStats.currentCooldown, attackStats.AtkStats.AttackCooldown);
    }
}
