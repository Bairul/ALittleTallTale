using UnityEngine;

[CreateAssetMenu(fileName = "DashStatsScriptableObject", menuName = "ScriptableObjects/Dash")]
public class DashStatsScriptableObject : SkillStatsScriptableObject
{
    [SerializeField]
    private float dashSpeed;
    public float DashSpeed { get => dashSpeed; private set => dashSpeed = value; }

    [SerializeField]
    private float dashDistance;
    public float DashDistance { get => dashDistance; private set => dashDistance = value; }

    [SerializeField]
    private float dashCooldown;
    public float DashCooldown { get => dashCooldown; private set => dashCooldown = value; }

    [SerializeField]
    private float dashDuration;
    public float DashDuration { get => dashDuration; private set => dashDuration = value; }

    [SerializeField]
    private DashBehavior dashBehavior;
    public DashBehavior DashBehavior { get => dashBehavior; private set => dashBehavior = value; }
}
