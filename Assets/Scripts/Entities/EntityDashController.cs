using System.Collections;
using UnityEngine;

public class EntityDashController : MonoBehaviour
{
    private DashStatsScriptableObject dashStats;
    private PlayerController playerController;
    private bool canDash;
    private float dashCooldownTimer;

    void Awake()
    {
        canDash = true;
    }

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        dashStats = PlayerManager.Instance.Stats.CharStats.DashSkill;
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
        playerController.canMove = false;
        dashStats.DashBehavior.Dash(playerController, dashStats);

        yield return new WaitForSeconds(dashStats.DashDuration);
        playerController.canMove = true;
        canDash = true;
        dashCooldownTimer = dashStats.DashCooldown;
    }
}
