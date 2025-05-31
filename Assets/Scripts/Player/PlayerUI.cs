using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public StatBar healthBar;
    public StatBar xpBar;
    public PlayerLevelingUI levelingUI;
    public InventoryUI inventoryUI;
    public StatBarAnimated dashBar;
    public StatBarAnimated basicBar;

    [SerializeField] private GameObject levelTextObject;
    private TextMeshProUGUI levelText;

    void Start()
    {
        levelText = levelTextObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetLevel(int level)
    {
        levelText.text = "" + level;
    }
}
