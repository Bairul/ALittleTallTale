using UnityEngine;

public class PlayerStats : LivingEntityStats
{
    private CharacterStatsScriptableObject charStats;
    public CharacterStatsScriptableObject CharStats { get => charStats; private set => charStats = value;}

    [HideInInspector] public float currentCritRate;
    [HideInInspector] public float currentCritDmg;

    // Magnet
    [SerializeField] private PlayerMagnet playerMagnet;
    [HideInInspector] public float currentMagnetRange;

    // Experience
    private int currentExperience;
    private int currentExperienceCap;
    private int currentLevel = 1;
    private int currentRangeIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        charStats = (CharacterStatsScriptableObject) stats;

        currentCritRate = charStats.CritRate;
        currentCritDmg = charStats.CritDamage;
    }

    void Start()
    {
        UpdateExperienceCap();
        UpdateMagnetRange(charStats.MagnetRange);
    }

    public void UpdateMagnetRange(float radius)
    {
        currentMagnetRange = radius;
        playerMagnet.Range.radius = currentMagnetRange;
    }

    void LevelUp()
    {
        currentLevel++;
        currentExperience -= currentExperienceCap;

        UpdateExperienceCap();
    }

    public void IncreaseExperience(int amount)
    {
        if (currentLevel >= charStats.MaxLevel) return;

        currentExperience += amount;

        if (currentExperience >= currentExperienceCap)
        {
            LevelUp();
        }
    }

    private void UpdateExperienceCap()
    {
        if (currentRangeIndex >= charStats.LevelRanges.Count) return;

        if (currentLevel > charStats.LevelRanges[currentRangeIndex].maxLevel)
        {
            currentRangeIndex++;
        }

        if (currentRangeIndex >= charStats.LevelRanges.Count) return;

        currentExperienceCap = charStats.LevelRanges[currentRangeIndex].experienceCap;
    }

    protected override void DamageTaken(float damage)
    {
        currentHealth -= damage;
    }

    protected override void Kill()
    {
        Debug.Log("You Died");
    }
}
