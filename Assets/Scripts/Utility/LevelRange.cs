[System.Serializable]
public class LevelRange
{
    public int minLevel;        // The minimum level for this range; Inclusive
    public int maxLevel;        // The maximum level for this range; Inclusive
    public int experienceCap;   // The experience required to level up in this range

    public bool Includes(int level) => level >= minLevel && level <= maxLevel;
}
