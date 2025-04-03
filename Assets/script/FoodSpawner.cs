using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab; // Prefab của thức ăn
    public int foodCount = 20; // Số lượng thức ăn trên bản đồ
    public GameObject plane; // Thay Terrain bằng Plane

    private void Start()
    {
        if (plane == null)
        {
            Debug.LogError("⚠️ FoodSpawner: Chưa gán Plane! Hãy gán trong Inspector.");
            return;
        }

        for (int i = 0; i < foodCount; i++)
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        // Lấy kích thước thực tế của Plane (dựa trên scale)
        Vector3 planeSize = plane.transform.localScale * 28f; // Plane gốc là 10x10 nên nhân với scale
        Vector3 planePosition = plane.transform.position;

        // Xác định phạm vi spawn dựa trên kích thước Plane
        float minX = planePosition.x - planeSize.x / 2;
        float maxX = planePosition.x + planeSize.x / 2;
        float minZ = planePosition.z - planeSize.z / 2;
        float maxZ = planePosition.z + planeSize.z / 2;

        float spawnX = Random.Range(minX, maxX);
        float spawnZ = Random.Range(minZ, maxZ);
        float spawnY = planePosition.y + 1.5f; // Đặt trên mặt phẳng

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, spawnZ);
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }
}