using UnityEngine;

public class HealthOrb : Collectible
{
    protected override void Collect(PlayerStats player)
    {
        player.HealHealth(collectibleData.CollectibleValue);
        Destroy(gameObject);
    }
}