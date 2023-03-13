using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneration
{
    public class SegmentSpawner : MonoBehaviour
    {
        
        // TODO: use instantiate() instead of object pooling, so the same tile cannot be transformed by itself
        // TODO: Turn Segments into prefabs 
        
        [Header("Spawning")]
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int firstGroupCount = 3;
        [Header("Segments")]
        [SerializeField] private List<Transform> segments = new();

        private Transform _lastSegment;
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
            Transform segment = segments[randomIndex];

            var spawnPos = GetSpawnPos();
            var copy =  Instantiate(segment, spawnPos, Quaternion.identity);

            var segmentComp = copy.transform.GetComponent<Segment>();
            segmentComp.StartMoving();
        
            _lastSegment = copy;
        }

        #region Helpers

        private int GetRandomIndex()
        {
            return _rand.Next(segments.Count);
        }

        private Vector3 GetSpawnPos()
        {
            if (_lastSegment == null) return spawnPoint.position;
        
            var length = _lastSegment.localScale.x;
            var vec = new Vector3(length, 0,0);
            return _lastSegment.transform.position - vec;
        }

        #endregion
    }
}