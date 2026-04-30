using UnityEngine;

public class NeedleSpawner : MonoBehaviour
{
    [Header("Needle Prefabs")]
    public GameObject[] needlePrefabs;
    
    [Header("Spawn Points")]
    public Transform[] spawnPoints;
    
    [Header("Spawn Settings")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2f;
    
    private float spawnTimer;
    private float nextSpawnTime;
    
    void Start()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            spawnPoints = new Transform[] { transform };
        }
        
        SetNextSpawnTime();
    }
    
    void Update()
    {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= nextSpawnTime)
        {
            SpawnNeedle();
            spawnTimer = 0;
            SetNextSpawnTime();
        }
    }
    
    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
    
    void SpawnNeedle()
    {
        if (needlePrefabs == null || needlePrefabs.Length == 0)
        {
            Debug.LogError("No needle prefabs assigned!");
            return;
        }
        
        GameObject selectedPrefab = needlePrefabs[Random.Range(0, needlePrefabs.Length)];
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        
        // Spawn with NO rotation - needles should already face down in prefab
        Instantiate(selectedPrefab, selectedSpawnPoint.position, Quaternion.identity);
    }
}