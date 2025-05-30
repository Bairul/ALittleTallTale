using UnityEngine;

[CreateAssetMenu(fileName = "DashToMouseBehavior", menuName = "ScriptableObjects/DashBehaviors/DashToMouseBehavior")]
public class DashToMouseBehavior : DashBehavior
{
    public override void Dash(PlayerController player, DashStatsScriptableObject data)
    {
        Vector2 toMouse = (GameWorld.Instance.GetMousePosition() - (Vector2)player.transform.position).normalized;
        player.Rigidbody.velocity = toMouse * data.DashSpeed;
    }
}
