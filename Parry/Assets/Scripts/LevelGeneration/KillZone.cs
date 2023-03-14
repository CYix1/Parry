using UnityEngine;

namespace LevelGeneration
{
    public class KillZone : MonoBehaviour
    {
        [SerializeField] private SegmentSpawner segmentSpawner;
    
        private void OnTriggerExit(Collider other)
        {
            if (!HasSegmentTag(other)) return;
            
            Destroy(other.gameObject);
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
