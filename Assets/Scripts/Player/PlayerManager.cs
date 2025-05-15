using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    private PlayerStats playerStats;
    public PlayerStats Stats { get => playerStats; private set => playerStats = value; }

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
            playerStats = GetComponent<PlayerStats>();
        }
    }
}
