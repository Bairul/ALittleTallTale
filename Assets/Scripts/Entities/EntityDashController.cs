using System.Collections;
using UnityEngine;

public class EntityDashController : MonoBehaviour
{
    [SerializeField]
    private DashStatsScriptableObject dashStats;
    private bool canDash;
    private float dashCooldownTimer;

    void Awake()
    {
        canDash = true;
    }

    void Update()
    {
        if (!canDash) return;

        dashCooldownTimer -= Time.deltaTime;

        if (dashCooldownTimer <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(InitiateDash());
        }
    }
    
    private IEnumerator InitiateDash()
    {
        canDash = false;
        PlayerController player = GetComponent<PlayerController>();
        player.canMove = false;
        dashStats.DashBehavior.Dash(player, dashStats);

        yield return new WaitForSeconds(dashStats.DashDuration);
        player.canMove = true;
        canDash = true;
        dashCooldownTimer = dashStats.DashCooldown;
    }
}
