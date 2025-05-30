using UnityEngine;

public abstract class DashBehavior : ScriptableObject
{
    public abstract void Dash(PlayerController player, DashStatsScriptableObject data);
}
