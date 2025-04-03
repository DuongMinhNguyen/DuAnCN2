using System.Collections.Generic;
using Fusion;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleSpawner : NetworkBehaviour
{
    public static AppleSpawner Instance; // Singleton để dễ gọi từ script khác
    public NetworkPrefabRef ApplePrefab; // Prefab của Apple (Network Object)
    public int maxApples = 10; // Giới hạn số lượng táo trên bản đồ
    private List<NetworkObject> spawnedApples = new List<NetworkObject>(); // Danh sách táo đã spawn

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public override void Spawned()
    {
        if (Runner.IsServer) // Chỉ server spawn apple
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnApple();
            }
        }
    }

    public void SpawnApples(int count)
    {
        if (!Runner.IsServer) return; // Chỉ Server mới có quyền spawn apple

        for (int i = 0; i < count; i++)
        {
            SpawnApple();
        }
    }

    private void SpawnApple()
    {
        if (spawnedApples.Count >= maxApples)
        {
            Runner.Despawn(spawnedApples[0]); // Xóa quả táo lâu đời nhất
            spawnedApples.RemoveAt(0);
        }

        Vector3 spawnPosition = new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f));
        NetworkObject newApple = Runner.Spawn(ApplePrefab, spawnPosition, Quaternion.identity);
        spawnedApples.Add(newApple);
    }
}