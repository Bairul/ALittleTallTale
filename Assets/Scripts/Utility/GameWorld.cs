using UnityEngine;

public class GameWorld : MonoBehaviour
{
    // Gamworld singleton
    public static GameWorld Instance { get; private set; }

    public AttackStatsScriptableObject[] allAttackSkills;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
