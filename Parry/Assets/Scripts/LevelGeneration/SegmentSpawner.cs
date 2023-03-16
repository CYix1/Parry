using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// TODO: first group should spawn at player

namespace LevelGeneration
{
    public class SegmentSpawner : MonoBehaviour
    {
        [Header("Spawning")] [SerializeField] private Transform spawnPoint;
        [SerializeField] private int firstGroupCount = 3;
        [Header("Segments")] [SerializeField] private List<MovingObject> segments = new();
        [SerializeField] private MovingObject fistSegment;
        [SerializeField] private float segmentSpeed = 10f;
        [SerializeField] private MovingObject intermediatePlaceHolder;
        [Header("")]
        private Transform _lastSegment;
        private System.Random _rand;
        
        //sry kerstin ich zerstöre dein script ups ~ Yixi
                  
       
        
        [Header("Decoration Models")]
        public GameObject[] houses;
        public GameObject[] trees;
        public GameObject[] undergrounds;


   

        #region Start

        private void Start()
        {
            _rand = new System.Random();
            SpawnFirst();
        }

        #endregion

        #region Spawning

        public void SpawnNext()
        {
            SpawnRandomSegment();
        }


        private void SpawnFirst()
        {
            SpawnSegment(fistSegment);
            for (int i = 0; i < firstGroupCount; i++)
            {
                SpawnRandomSegment();
            }
        }

        private void SpawnRandomSegment()
        {
            int randomIndex = GetRandomIndex();
            MovingObject segment = segments[randomIndex];

            SpawnSegment(segment);
        }

        private void SpawnSegment(MovingObject segment)
        {
            var spawnPos = GetSpawnPos(segment.transform);
            _lastSegment = Instantiate(segment.transform, spawnPos, Quaternion.identity);
            _lastSegment.GetComponent<MovingObject>().SetSpeed(segmentSpeed);
           
          

            SpawnIntermediate();
        }

        public GameObject RandomHouse() => houses[Random.Range(0, houses.Length)];
        public GameObject RandomTree() => trees[Random.Range(0, trees.Length)];
        public GameObject RandomUnderground() => undergrounds[Random.Range(0, undergrounds.Length)];


        private void SpawnIntermediate()
        {
            var spawnPos = GetSpawnPos(intermediatePlaceHolder.transform);
            _lastSegment = Instantiate(intermediatePlaceHolder.transform, spawnPos, Quaternion.identity);
            _lastSegment.GetComponent<MovingObject>().SetSpeed(segmentSpeed);
            DecoratorDelegator del = _lastSegment.GetComponent<DecoratorDelegator>();
            
            //spawn house at the points
            var temp=Instantiate(RandomHouse().transform, del.housSPLeft.position, del.housSPLeft.rotation, _lastSegment.transform);
            temp.transform.localScale = del.housSPLeft.localScale;
            
            temp=Instantiate(RandomHouse().transform, del.housSPRight.position,  del.housSPRight.rotation, _lastSegment.transform);
            temp.transform.localScale = del.housSPRight.localScale;

            //maybe spawn something
            if (Random.value > 0.4f)
            {
                //left trees
                for (int i = 0; i < del.TreeSPLeft.Length; i++)
                {
                    temp= Instantiate(RandomTree().transform, del.TreeSPLeft[i].position, Quaternion.identity,
                        _lastSegment.transform);
                    temp.transform.localScale = del.TreeSPLeft[i].localScale;
                }

                //right trees
                for (int i = 0; i < del.TreeSPRight.Length; i++)
                {
                    temp=  Instantiate(RandomTree().transform, del.TreeSPRight[i].position, Quaternion.identity,
                        _lastSegment.transform);
                    temp.transform.localScale = del.TreeSPRight[i].localScale;
                }
            }

            temp=  Instantiate(RandomUnderground().transform, del.underGroundSP.position, del.underGroundSP.rotation,
                _lastSegment.transform);
            temp.transform.localScale = del.underGroundSP.localScale;


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