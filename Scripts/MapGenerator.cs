using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform player;
    public List<GameObject> segmentPrefabs;
    public int startSegmentCount = 5;
    public float segmentLength = 10f;

    private float spawnZ = 0f;
    private List<GameObject> activeSegments = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < startSegmentCount; i++)
        {
            SpawnSegment();
        }
    }

    void Update()
    {
        if (player.position.z > spawnZ - (startSegmentCount * segmentLength))
        {
            SpawnSegment();
            RemoveOldSegment();
        }
    }

    void SpawnSegment()
    {
        GameObject prefab = segmentPrefabs[Random.Range(0, segmentPrefabs.Count)];
        GameObject segment = Instantiate(prefab, Vector3.forward * spawnZ, Quaternion.identity);

        activeSegments.Add(segment);
        spawnZ += segmentLength;
    }

    void RemoveOldSegment()
    {
        if (activeSegments.Count > startSegmentCount)
        {
            Destroy(activeSegments[0]);
            activeSegments.RemoveAt(0);
        }
    }
}
