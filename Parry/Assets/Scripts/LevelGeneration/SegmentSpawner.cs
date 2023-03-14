using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneration
{
    public class SegmentSpawner : MonoBehaviour
    {
        [Header("Spawning")] [SerializeField] private Transform spawnPoint;
        [SerializeField] private int firstGroupCount = 3;
        [Header("Segments")] [SerializeField] private List<Transform> segments = new();
        [SerializeField] private float segmentSpeed = 1f;

        private Transform _lastSegment;
        private System.Random _rand;

        #region Start

        private void Start()
        {
            _rand = new System.Random();
            SetSegmentSpeed();
            SpawnFirstGroup();
        }

        #endregion

        #region Spawning

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

            var spawnPos = GetSpawnPos(segment);
            _lastSegment = Instantiate(segment, spawnPos, Quaternion.identity);
        }

        #endregion

        #region Speed

        private void SetSegmentSpeed()
        {
            Segment.Speed = segmentSpeed;
        }
        
        private void Accelerate()
        {
            // TODO: increase speed over time
        }

        #endregion


        #region Helpers

        private int GetRandomIndex()
        {
            return _rand.Next(segments.Count);
        }

        private Vector3 GetSpawnPos(Transform newSegment)
        {
            // instantiate the first segment at specified spawnPoint
            if (_lastSegment == null) return spawnPoint.position;

            // calculate the distance between old and new segments' centers
            var lastSegmentLength = GetCenterToEdge(_lastSegment);
            var newSegmentLength = GetCenterToEdge(newSegment);
            var distanceBetweenCenters = lastSegmentLength + newSegmentLength;
            
            // subtract as we move towards positive X -> spawn behind last segment
            return _lastSegment.transform.position - distanceBetweenCenters;
        }

        private Vector3 GetCenterToEdge(Transform transform)
        {
            var xScale = transform.localScale.x;
            // divide by 2 as we want the distance between center and edge and not whole scale
            xScale *= 0.5f;
            return new Vector3(xScale, 0, 0);
        }

        #endregion
    }
}