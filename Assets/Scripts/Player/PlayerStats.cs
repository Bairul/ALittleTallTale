using UnityEngine;

public class PlayerStats : LivingEntityStats
{
    private CharacterStatsScriptableObject charStats;
    public CharacterStatsScriptableObject CharStats { get => charStats; private set => charStats = value; }

    [HideInInspector] public float currentCritRate;
    [HideInInspector] public float currentCritDmg;

    // Magnet
    [SerializeField] private PlayerMagnet playerMagnet;
    [HideInInspector] public float currentMagnetRange;

    // healthbar
    [SerializeField] private StatBar playerHealthBar;

    // Experience
    [SerializeField] private StatBar playerXpBar;
    private PlayerLevelingSystem levelSystem;

    protected override void Awake()
    {
        base.Awake();
        charStats = (CharacterStatsScriptableObject)stats;

        currentCritRate = charStats.CritRate;
        currentCritDmg = charStats.CritDamage;
        levelSystem = new PlayerLevelingSystem(charStats.LevelRanges);
        levelSystem.OnLevelUp += OnLevelUp;
    }

    void Start()
    {
        playerXpBar.SetValue(0, 1);
        UpdateMagnetRange(charStats.MagnetRange);
    }

    public void IncreaseExperience(int amount)
    {
        if (levelSystem.IsMaxLevel) return;

        levelSystem.IncreaseExperience(amount);
        UpdateXPBar();
    }


    public void UpdateMagnetRange(float radius)
    {
        currentMagnetRange = radius;
        playerMagnet.Range.radius = currentMagnetRange;
    }

    private void OnLevelUp()
    {
        Debug.Log("LEVELED UP!!!!!\n You are now Level " + levelSystem.CurrentLevel);
    }

    private void UpdateXPBar()
    {
        if (levelSystem.IsMaxLevel)
            playerXpBar.SetValue(1, 1); // Full bar or hide bar
        else
            playerXpBar.SetValue(levelSystem.CurrentExperience, levelSystem.ExperienceCap);
    }


    protected override void AdjustHealth(float value)
    {
        base.AdjustHealth(value);
        playerHealthBar.SetValue(currentHealth, currentMaxHealth);
    }

    protected override void Kill()
    {
        Debug.Log("You Died");
    }
}
