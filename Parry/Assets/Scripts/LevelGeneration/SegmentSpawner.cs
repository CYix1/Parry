using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneration
{
    public class SegmentSpawner : MonoBehaviour
    {
        [Header("Spawning")]
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int firstGroupCount = 3;
        [Header("Segments")]
        [SerializeField] private List<Segment> segments = new();

        private Segment _lastSegment;
        private System.Random _rand;

        #region Start

        private void Start()
        {
            _rand = new System.Random();
            SpawnFirstGroup();
        }

        #endregion

    
        public void SpawnNext()
        {
            SpawnSegment();
        }

        private void SpawnFirstGroup()
        {
            for (int i = 0; i < firstGroupCount; i++)
            {
                SpawnSegment();
            }
        }

        private void SpawnSegment()
        {
            int randomIndex = GetRandomIndex();
            Segment segment = segments[randomIndex];

            var spawnPos = GetSpawnPos();
            segment.SpawnAt(spawnPos);
        
            _lastSegment = segments[randomIndex];
        }

        #region Helpers

        private int GetRandomIndex()
        {
            return _rand.Next(segments.Count);
        }

        private Vector3 GetSpawnPos()
        {
            if (_lastSegment == null) return spawnPoint.position;
        
            var length = _lastSegment.GetVectorWithXLength();
            return _lastSegment.transform.position -  length;
        }

        #endregion
    }
}