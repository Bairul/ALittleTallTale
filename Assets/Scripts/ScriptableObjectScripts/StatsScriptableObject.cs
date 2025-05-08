using UnityEngine;

public class StatsScriptableObject : ScriptableObject
{
    [Header("Base Stats")]
    [SerializeField]
    private float health;
    public float Health { get => health; private set => health = value; }

    [SerializeField]
    private float strength;
    public float Strength { get => strength; private set => strength = value; }

    [SerializeField]
    private float movementSpeed;
    public float MovementSpeed { get => movementSpeed; private set => movementSpeed = value; }

    [SerializeField]
    private float attackSpeed;
    public float AttackSpeed { get => attackSpeed; private set => attackSpeed = value; }

    [SerializeField]
    private float iFrameDuration;
    public float IFrameDuration { get => iFrameDuration; private set => iFrameDuration = value; }
}

