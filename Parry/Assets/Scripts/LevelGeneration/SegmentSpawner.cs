using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneration
{
    public class SegmentSpawner : MonoBehaviour
    {
        [Header("Spawning")] [SerializeField] private Transform spawnPoint;
        [SerializeField] private int firstGroupCount = 3;
        [Header("Segments")] [SerializeField] private List<MovingObject> segments = new();
        [SerializeField] private float segmentSpeed = 10f;
        [SerializeField] private MovingObject intermediatePlaceHolder;

        private Transform _lastSegment;
        private System.Random _rand;

        #region Start

        private void Start()
        {
            _rand = new System.Random();
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
            MovingObject segment = segments[randomIndex];

            var spawnPos = GetSpawnPos(segment.transform);
            _lastSegment = Instantiate(segment.transform, spawnPos, Quaternion.identity);
            _lastSegment.GetComponent<MovingObject>().SetSpeed(segmentSpeed);

            SpawnIntermediate();
        }

        private void SpawnIntermediate()
        {
            var spawnPos = GetSpawnPos(intermediatePlaceHolder.transform);
            _lastSegment = Instantiate(intermediatePlaceHolder.transform, spawnPos, Quaternion.identity);
            _lastSegment.GetComponent<MovingObject>().SetSpeed(segmentSpeed);
        }

        #endregion

        #region Speed

        private void Accelerate()
        {
            // TODO: increase speed over time
        }

        #endregion


        #region Helpers

        private int GetRandomIndex()
        {
            // segments.Count as it is used to get a random segment from the list
            // Next(x) returns a random value in [0,x[
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

        private Vector3 GetCenterToEdge(Transform objToSpawn)
        {
            var xScale = objToSpawn.localScale.x;
            // divide by 2 as we want the distance between center and edge and not whole scale
            xScale *= 0.5f;
            return new Vector3(xScale, 0, 0);
        }

        #endregion
    }
}