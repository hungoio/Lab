using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject itemPrefab;

    public float spawnDistance = 30f;
    public float spacing = 10f;
    public float sideOffset = 4f; // khoảng cách sang trái / phải

    float lastZ;

    void Start()
    {
        // spawn trước mặt player ngay từ đầu
        lastZ = player.position.z + spawnDistance;
    }

    void Update()
    {
        if (player.position.z + spawnDistance > lastZ)
        {
            SpawnItem();
            lastZ += spacing;
        }
    }

    void SpawnItem()
    {
        // random trái hoặc phải
        float side = Random.value < 0.5f ? -sideOffset : sideOffset;

        Vector3 pos = new Vector3(
            side,
            0,
            lastZ
        );

        Instantiate(itemPrefab, pos, Quaternion.identity);
    }
}
