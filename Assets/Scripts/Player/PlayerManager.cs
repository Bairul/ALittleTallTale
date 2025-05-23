using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    private PlayerStats playerStats;
    public PlayerStats Stats { get => playerStats; private set => playerStats = value; }

    private PlayerInventory playerInventory;
    public PlayerInventory PlayerInventory { get => playerInventory; private set => playerInventory = value; }

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
            playerInventory = transform.Find("Inventory").GetComponent<PlayerInventory>();
        }
    }
}
