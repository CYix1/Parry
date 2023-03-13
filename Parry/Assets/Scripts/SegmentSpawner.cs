using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SegmentSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<Segment> segments = new();

    private void Start()
    {
        InvokeRepeating(nameof(SpawnSegment), 1, 3);
    }

    private void SpawnSegment()
    {
        int randomIndex = GetRandomIndex();
        Debug.Log("SegmentSpawning: Rand = " + randomIndex);
        Segment segment = segments[randomIndex];
        
        segment.SpawnAt(spawnPoint.position);
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, segments.Count);
    }
}