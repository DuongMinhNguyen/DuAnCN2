using System;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using Random = UnityEngine.Random;

public class SnakeController : NetworkBehaviour
{
    public float MoveSpeed = 5.0f;
    public float SteerSpeed = 180f;
    public float BodySpeed = 5f;
    public int Gap = 10;

    public GameObject BodyPreFab;
    public GameObject ApplePrefab;
    public NetworkPrefabRef AppleNetworkPrefab;
    
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> bodyPos = new List<Vector3>();


    void Start()
    {
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }
    public override void FixedUpdateNetwork()
    {
        // Di chuyển đầu rắn
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        
        // Xoay đầu rắn theo input
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);
        
        // Thêm vị trí đầu rắn vào danh sách
        bodyPos.Insert(0, transform.position);

        // Giới hạn kích thước danh sách vị trí
        if (bodyPos.Count > (BodyParts.Count + 1) * Gap)
        {
            bodyPos.RemoveAt(bodyPos.Count - 1);
        }

        // Cập nhật vị trí từng phần thân rắn
        for (int i = 0; i < BodyParts.Count; i++)
        {
            Vector3 point = bodyPos[Mathf.Clamp(i * Gap, 0, bodyPos.Count - 1)];
            GameObject body = BodyParts[i];
            
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
        }
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPreFab);
        
        if (BodyParts.Count > 0)
        {
            body.transform.position = BodyParts[BodyParts.Count - 1].transform.position;
        }
        else
        {
            body.transform.position = transform.position - transform.forward * 1.5f;
        }

        BodyParts.Add(body);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("apple"))
        {
            Destroy(other.gameObject);
            GrowSnake();
            SpawnApple();
            //AppleSpawner.Instance.SpawnApples(Random.Range(1, 4));
        }
    }
    private void SpawnApple()
    {
        if (!Runner.IsServer) return; // Chỉ Server mới được spawn Apple

        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 1, Random.Range(-10f, 10f));
    
        // Kiểm tra nếu AppleNetworkPrefab có được đăng ký không
        if (AppleNetworkPrefab.IsValid)
        {
            Runner.Spawn(AppleNetworkPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("AppleNetworkPrefab chưa được đăng ký trong NetworkObject Table!");
        }
    }

}
