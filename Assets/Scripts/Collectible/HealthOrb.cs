using UnityEngine;

public class HealthOrb : Collectible
{
    protected override void Collect(PlayerStats player)
    {
        player.currentHealth = Mathf.Min(player.currentHealth + collectibleData.CollectibleValue, player.currentMaxHealth);
        Destroy(gameObject);
    }
}