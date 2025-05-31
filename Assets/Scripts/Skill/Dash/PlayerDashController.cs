using System.Collections;
using UnityEngine;

public class PlayerDashController : MonoBehaviour
{
    private DashStatsScriptableObject dashStats;
    private PlayerController playerController;
    private PlayerStats playerStats;
    private float dashCooldownTimer;
    private bool dashable;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerStats = GetComponent<PlayerStats>();
        dashable = true;
        dashStats = playerStats.CharStats.DashSkill;
        dashCooldownTimer = dashStats.DashCooldown;
    }

    void Update()
    {
        if (!dashable) return;

        dashCooldownTimer += Time.deltaTime;

        if (dashCooldownTimer >= dashStats.DashCooldown)
        {
            dashCooldownTimer = dashStats.DashCooldown;
            playerStats.PlayerUI.dashBar.SetValue(1, 1); // full
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(InitiateDash());
            }
        }
        else
        {
            playerStats.PlayerUI.dashBar.SetValue(dashCooldownTimer, dashStats.DashCooldown);
        }
    }

    private IEnumerator InitiateDash()
    {
        dashable = false;
        playerController.canMove = false;
        dashStats.DashBehavior.Dash(playerController, dashStats);

        yield return new WaitForSeconds(dashStats.DashDuration);
        playerController.canMove = true;
        dashCooldownTimer = 0;
        dashable = true;
    }
}
