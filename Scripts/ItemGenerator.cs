using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject itemPrefab;
    public float radius = 10f;
    public float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0f;
        }
    }

    void SpawnItem()
    {
        Vector2 randomPos = Random.insideUnitCircle * radius;
        Vector3 spawnPos = player.position + new Vector3(randomPos.x, 0f, randomPos.y);

        Instantiate(itemPrefab, spawnPos, Quaternion.identity);
    }
}
