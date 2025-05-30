using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerLevelingSystem
{
    private int currentLevel = 1;
    private int currentExperience = 0;

    private readonly List<LevelRange> levelRanges;

    public int CurrentLevel => currentLevel;
    public int CurrentExperience => currentExperience;
    public int ExperienceCap => GetExperienceCapForLevel(currentLevel);

    public bool IsMaxLevel => currentLevel >= GetMaxLevel();
    public event Action OnLevelUp;

    public PlayerLevelingSystem(List<LevelRange> levelRanges)
    {
        this.levelRanges = levelRanges;
        if (levelRanges.Count == 0) throw new ArgumentException("LevelRanges must not be empty.");
    }

    public void IncreaseExperience(int amount)
    {
        if (IsMaxLevel) return;

        currentExperience += amount;

        while (currentExperience >= ExperienceCap && !IsMaxLevel)
        {
            currentExperience -= ExperienceCap;
            currentLevel++;
            OnLevelUp?.Invoke();
        }

        // Prevent overfill after hitting max level
        if (IsMaxLevel) currentExperience = 0;
    }

    private int GetExperienceCapForLevel(int level)
    {
        LevelRange range = levelRanges.FirstOrDefault(r => r.Includes(level)) ?? throw new Exception($"No LevelRange includes level {level}");
        return range.experienceCap;
    }

    private int GetMaxLevel()
    {
        return levelRanges.Max(r => r.maxLevel);
    }
}