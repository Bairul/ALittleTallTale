using UnityEngine;

[CreateAssetMenu(fileName = "BlinkToMouseBehavior", menuName = "ScriptableObjects/DashBehaviors/BlinkToMouseBehavior")]
public class BlinkToMouseBehavior : DashBehavior
{
    public override void Dash(PlayerController player, DashStatsScriptableObject data)
    {
        Vector2 toMouse = (GameWorld.Instance.GetMousePosition() - (Vector2)player.transform.position).normalized;
        player.transform.position += (Vector3) (toMouse * data.DashDistance);
    }
}
