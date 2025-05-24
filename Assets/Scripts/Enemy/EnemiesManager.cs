using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemiesManager : MonoBehaviour
{
    // singleton
    public static EnemiesManager Instance { get; private set; }
    public List<GameObject> ActiveEnemies = new();

    // fields
    [SerializeField] private Tilemap spawnTilemap;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnOutsideMargin;
    [SerializeField] private EnemyWave[] enemyWaves;

    private const int MAX_RETRIES = 12;
    private float spawnTimer = 0f;
    private float gameTime = 0f;

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

    void Update()
    {
        spawnTimer += Time.deltaTime;
        gameTime += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            TrySpawnEnemy();
        }
    }

    // === enemy spawning === \\

    private void TrySpawnEnemy()
    {
        Vector3Int tile = GetValidTile();
        if (tile == Vector3Int.zero) return;

        EnemyStatsScriptableObject enemy = GetCurrentWeightedEnemy();
        if (enemy == null) return;

        GameObject enemyInstance = Instantiate(enemy.EntityPrefab, spawnTilemap.CellToWorld(tile) + spawnTilemap.tileAnchor, Quaternion.identity);
        enemyInstance.transform.SetParent(transform, worldPositionStays: false);
        Debug.Log("Spawned in enemy");
    }

    private Vector3Int GetValidTile()
    {
        for (int attempt = 0; attempt < MAX_RETRIES; attempt++)
        {
            Vector3Int cellPos = spawnTilemap.WorldToCell(GetRandomPositionOutsideCamera());

            if (spawnTilemap.HasTile(cellPos))
            {
                return cellPos;
            }
        }
        Debug.LogWarning("Failed to spawn enemy given " + MAX_RETRIES + " tries!");
        return Vector3Int.zero;
    }

    private Vector3 GetRandomPositionOutsideCamera()
    {
        Bounds camBounds = GetCameraBounds();

        // Expand bounds by margin
        float xMin = camBounds.min.x - spawnOutsideMargin;
        float xMax = camBounds.max.x + spawnOutsideMargin;
        float yMin = camBounds.min.y - spawnOutsideMargin;
        float yMax = camBounds.max.y + spawnOutsideMargin;

        // Choose edge region (top, bottom, left, right)
        int edge = Random.Range(0, 4);
        float x = 0, y = 0;

        switch (edge)
        {
            case 0: // Top
                x = Random.Range(xMin, xMax);
                y = yMax + Random.Range(0f, spawnOutsideMargin);
                break;
            case 1: // Bottom
                x = Random.Range(xMin, xMax);
                y = yMin - Random.Range(0f, spawnOutsideMargin);
                break;
            case 2: // Left
                x = xMin - Random.Range(0f, spawnOutsideMargin);
                y = Random.Range(yMin, yMax);
                break;
            case 3: // Right
                x = xMax + Random.Range(0f, spawnOutsideMargin);
                y = Random.Range(yMin, yMax);
                break;
        }

        return new Vector3(x, y, 0);
    }


    private Bounds GetCameraBounds()
    {
        Vector3 camPos = mainCamera.transform.position;
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;
        return new Bounds(camPos, new Vector3(width, height, 1f));
    }

    private EnemyStatsScriptableObject GetCurrentWeightedEnemy()
    {
        EnemyWave currentSet = enemyWaves.LastOrDefault(set => gameTime >= set.startTime);
        if (currentSet != null)
        {
            WeightedObject selected = WeightedObject.GetRandomWeightedObject(currentSet.enemies);
            return selected.item as EnemyStatsScriptableObject;
        }

        return null;
    }
}
