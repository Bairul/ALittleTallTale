public class ExperienceOrb : Collectible
{
    protected override void Collect(PlayerStats player)
    {
        player.IncreaseExperience((int) collectibleData.CollectibleValue);
        Destroy(gameObject);
    }
}