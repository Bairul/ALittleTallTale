using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager Instance { get; private set; }
    public readonly List<GameObject> ActiveEnemies = new();

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

    public void Register(GameObject enemy) => ActiveEnemies.Add(enemy);
    public void Unregister(GameObject enemy) => ActiveEnemies.Remove(enemy);

    public List<GameObject> GetNearestEnemies(Vector3 playerPosition, int count)
    {
        // Sort by distance to player
        return ActiveEnemies
            .OrderBy(e => (e.transform.position - playerPosition).sqrMagnitude)
            .Take(count)
            .ToList();
    }
}
