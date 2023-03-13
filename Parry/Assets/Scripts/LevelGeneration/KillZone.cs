using UnityEngine;

namespace LevelGeneration
{
    public class KillZone : MonoBehaviour
    {
        [SerializeField] private SegmentSpawner segmentSpawner;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!HasSegmentTag(other)) return;

            Segment segmentComponent = GetSegmentComponent(other);
        
            segmentComponent.Reset();
            segmentSpawner.SpawnNext();
        }

        private bool HasSegmentTag(Collider other)
        {
            return other.CompareTag("Segment");
        }

        private Segment GetSegmentComponent(Component other)
        {
            return other.GetComponent<Segment>();
        }
    }
}
