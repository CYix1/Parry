using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelGeneration
{
    public class SegmentSpawner : MonoBehaviour
    {
        [Header("Spawning")] 
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float segmentSpeed = 8f;
        [SerializeField] private int firstGroupCount = 10;
        
        [Header("Segments")]
        [SerializeField] private MovingObject fistSegment;
        [SerializeField] private List<MovingObject> segments = new();
        [SerializeField] private List<MovingObject> intermediates = new();

        [Header("Decoration Models")]
        public GameObject[] houses;
        public GameObject[] trees;
        public GameObject[] undergrounds;

        private System.Random _rand;
        private Transform _lastSegment;
   

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
            int randomIndex = GetRandomSegmentIndex();
            MovingObject segment = segments[randomIndex];

            SpawnSegment(segment);
        }

        private void SpawnSegment(MovingObject segment)
        {
            var spawnPos = GetSpawnPos(segment.transform);
            _lastSegment = Instantiate(segment.transform, spawnPos, Quaternion.identity);
            _lastSegment.GetComponent<MovingObject>().SetSpeed(segmentSpeed);
           
          

            SpawnRandomIntermediateAndDeco();
        }

        public GameObject RandomHouse() => houses[Random.Range(0, houses.Length)];
        public GameObject RandomTree() => trees[Random.Range(0, trees.Length)];
        public GameObject RandomUnderground() => undergrounds[Random.Range(0, undergrounds.Length)];


        private void SpawnRandomIntermediateAndDeco()
        {
            var randomIndex = GetRandomIntermediateIndex();
            MovingObject intermediate = intermediates[randomIndex];
            
            var spawnPos = GetSpawnPos(intermediate.transform);
            _lastSegment = Instantiate(intermediate.transform, spawnPos, Quaternion.identity);
            _lastSegment.GetComponent<MovingObject>().SetSpeed(segmentSpeed);
            
            DecoratorDelegator del = _lastSegment.GetComponentInChildren<DecoratorDelegator>();
            Debug.Log(del);
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

        }

        #endregion

        #region Speed

        private void Accelerate()
        {
            // TODO: increase speed over time
        }

        #endregion


        #region Helpers

        private int GetRandomSegmentIndex()
        {
            // segments.Count as it is used to get a random segment from the list
            // Next(x) returns a random value in [0,x[
            return _rand.Next(segments.Count);
        }
        private int GetRandomIntermediateIndex()
        {
            // ->  see GetRandomSegmentIndex()
            return _rand.Next(intermediates.Count);
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