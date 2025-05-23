using System.Collections.Generic;
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

    [SerializeField] private PlayerUI playerUI;
    private PlayerLevelingSystem levelSystem;
    private PlayerSkillPool skillPool;

    protected override void Awake()
    {
        base.Awake();
        charStats = (CharacterStatsScriptableObject)stats;
        skillPool = GetComponent<PlayerSkillPool>();

        currentCritRate = charStats.CritRate;
        currentCritDmg = charStats.CritDamage;
        levelSystem = new PlayerLevelingSystem(charStats.LevelRanges);
    }

    void Start()
    {
        UpdateMagnetRange(charStats.MagnetRange);
        skillPool.Initialize(charStats.ElementalAffinities);
        levelSystem.OnLevelUp += OnLevelUp;
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
        playerUI.levelingUI.ShowSkillOptions(skillPool.OfferRandomSkills(3));
        playerUI.SetLevel(levelSystem.CurrentLevel);
    }

    private void UpdateXPBar()
    {
        if (levelSystem.IsMaxLevel)
            playerUI.xpBar.SetValue(1, 1); // Full bar or hide bar
        else
            playerUI.xpBar.SetValue(levelSystem.CurrentExperience, levelSystem.ExperienceCap);
    }


    protected override void AdjustHealth(float value)
    {
        base.AdjustHealth(value);
        playerUI.healthBar.SetValue(currentHealth, currentMaxHealth);
    }

    protected override void Kill()
    {
        Debug.Log("You Died");
    }
}
