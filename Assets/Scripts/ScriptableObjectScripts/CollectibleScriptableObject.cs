using UnityEngine;
using static AllEnums;

[CreateAssetMenu(fileName ="CollectibleScriptableObject", menuName ="ScriptableObjects/Collectible")]
public class CollectibleScriptableObject : ScriptableObject
{
    [SerializeField]
    private CollectibleType collectibleType;
    public CollectibleType CollectibleType { get => collectibleType; private set => collectibleType = value; }

    [SerializeField]
    private GameObject collectiblePrefab;
    public GameObject CollectiblePrefab { get => collectiblePrefab; private set => collectiblePrefab = value; }

    [SerializeField]
    private float collectibleValue;
    public float CollectibleValue { get => collectibleValue; private set => collectibleValue = value; }

    [SerializeField]
    private float pullSpeed;
    public float PullSpeed { get => pullSpeed; private set => pullSpeed = value; }
}
