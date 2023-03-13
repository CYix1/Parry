using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SegmentSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<Segment> segments = new();

    #region Start

    private void Start()
    {
        SpawnNext();
    }

    #endregion

    #region public

    public void SpawnNext()
    {
        SpawnSegment();
    }

    #endregion

    #region internal

    private void SpawnSegment()
    {
        int randomIndex = GetRandomIndex();
        Segment segment = segments[randomIndex];

        segment.SpawnAt(spawnPoint.position);
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, segments.Count);
    }

    #endregion
}